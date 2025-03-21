﻿using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Interfaces;
using Application.Services;
using DigitalNotesManager.Application.DTOs;
using DigitalNotesManager.Application.Interfaces;
using UI.Forms;

namespace UI
{
    public partial class NoteCard : UserControl
    {
        private readonly int noteId;
        private readonly DataGridView gridView;
        private readonly INoteService _noteService;
        private readonly ICategoryService _categoryService;
        int idUser;

        #region Constructor
        public NoteCard(int id, NoteDTO note, DataGridView gridView, INoteService noteService, ICategoryService categoryService)
            {
                InitializeComponent();
                 this.noteId = note.Id;
                this.gridView = gridView;
                this._noteService = noteService;
                this.BackColor = Color.Bisque;
                this.Padding = new Padding(10);
                this.Margin = new Padding(10);
                this.BorderStyle = BorderStyle.FixedSingle;
                _categoryService = categoryService;
                LoadNoteCard(note);
            }
        #endregion

        #region Display CardNote  
        private async void LoadNoteCard(NoteDTO note)
        {
            await RefreshDisplayCard(note);
        }

        public async Task RefreshDisplayCard(NoteDTO note)
        {
            this.TitleLabel.Text = note.Title;
            this.ReminderDateLabel.Text = note.ReminderDate?.ToString() ?? DateTime.Now.ToString();

            if (note.CategoryId.HasValue)
            {
                var category = await _categoryService.GetCategoryByIdAsync(note.CategoryId.Value);
                this.CategoryLabel.Text = category != null ? category.Name : "No Category";
            }
            else
            {
                this.CategoryLabel.Text = "No Category";
            }
        }


        #endregion


        #region Delete | Edit Button
        private async void DeleteNoteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("You Want To Delete This Note?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                await _noteService.DeleteNoteAsync(this.noteId);

                if (this.Parent is FlowLayoutPanel parentPanel)
                {
                    parentPanel.Controls.Remove(this);
                    parentPanel.Refresh();
                }

                await RefreshGridView();
            }
        }

        private async void EditNoteBtn_Click(object sender, EventArgs e)
        {
            var note = await _noteService.GetNoteByIdAsync(this.noteId);
            string content = note.Content ?? "";

            NoteForm noteForm = new NoteForm(note, this.Parent as FlowLayoutPanel, gridView, _noteService, _categoryService);
            noteForm.MdiParent = this.ParentForm;

            noteForm.FormClosed += async (s, args) =>
            {
                var updatedNote = await _noteService.GetNoteByIdAsync(this.noteId);
                RefreshDisplayCard(updatedNote);
                await RefreshGridView();
                
            };

            noteForm.Show();
        }

        private async Task RefreshGridView()
        {
            var notes = await _noteService.GetAllNotesAsync(idUser);
            gridView.DataSource = notes.Select(n => new { n.Id, n.Title, n.ReminderDate, n.CategoryId,n.CreatedDate,n.UserId }).ToList();
        }

        #endregion

        
    }
}
