# 📒 Digital Notes Manager
A powerful, lightweight note-taking application built with Clean Architecture, Entity Framework (Code First), and Windows Forms (WinForms). It offers user authentication, note categorization, reminders, and rich text editing.

## 📦 Architecture & Tech Stack
   - Clean Architecture – Organized into layers (UI, Application, Domain, Infrastructure).
   - Entity Framework Core (Code First) – Manages Notes, Users, and Categories.
   - Interfaces & Repositories – Follows a structured repository pattern.
   - DTO (Data Transfer Objects) – Separates domain models from UI models.
   - Services Layer – Handles business logic.

##  🚀 Features:
📝 Note Management
   - Custom Categories & Card Notes – Organize notes in categories with a visually appealing card-based UI.
   - Panel Display – Displays notes in a panel with styled card UI.
   - Sorting – Sort notes by title, reminder date, and creation date.
   - Search – Search notes by content or category.
   - Markdown & Rich Text Support – Format notes with bold, italic, and underline.
   - Custom Category for UI Change –
       - Allows users to switch NoteForm UI based on category.
       - Change from RichText mode to Checkbox mode.
       - Dynamically changes background color for better visibility.
      
🔐 User Authentication
   - Login & Registration – Secure authentication system.
   - Validation – Ensures valid user inputs for login and signup.

📂 File Operations (MenuStrip)
   - File Menu:
      - New – Create a new note.
      - Open – Open an existing .txt or .rtf file.
      - Save – Save the current note.
      - Exit – Close the application.
     
   - Edit Menu:
      - Cut, Copy, Paste – Standard text editing options.
      - Format – Apply bold, italic, and underline styles.
     
   - View Menu:
      - Notes List – View all notes.
      - Arrange Windows – Organize windows as Tile or Cascade
     
   - Help Menu:
      - About – Opens an "About" form with app details.
  
⏰ Reminder & Alarm System
   - Alarm Button – Displays an image-based button to set reminders.
   - Notification Panel – Triggers an alarm when the reminder date is reached.
     
🖼️ UI & User Experience
   - Panel-based Layout – Displays all card notes in a stylish, grid-based format.
   - Image Buttons – Buttons for New Note, Edit, Delete with icons.
   - GridView for Notes – View and manage notes efficiently.
   - Customizable UI per Category – Change UI style & color dynamically when selecting a category.
     
## 🛠️ Code Overview
🖥️ User Interface (UI)
  - WinForms-based Panel & GridView for displaying notes.
  - MenuStrip for File, Edit, View, and Help operations.
    
📂 File Handling
  - Uses JFileChooser for file selection.
  - Saves content with BufferedWriter.
  - Supports printing with print() from JTextArea.
    
🔄 Authentication & Services
  - Login & Registration services with validation.
  - DTOs used to transfer data efficiently.
  - 
📊 Sorting & Filtering
  - Notes can be sorted by title, reminder date, or creation date.
  - Search by content or category.

## 🚀Get Started:
- Clone the Repository : Start by cloning the repository to your local environment.
```sh
   git clone https://github.com/YOUR_USERNAME/YOUR_REPOSITORY.git
   cd DigitalNotesManager
```
- Setup the Database
     -Ensure you have SQL Server installed.
     -Open Package Manager Console in Visual Studio and run:
```sh
Update-Database
```
- Run the Application

You're welcome to edit or add more sections if needed! 😊



