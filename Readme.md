📌 Ticket Updation Tool
Overview

This Windows Forms application automates ticket updates in Azure DevOps using data from an Excel template. Users can upload the file through the UI, and the app converts the data into JSON and calls the required APIs to update tickets.

⚠️ Note: This project is still a work in progress and not fully completed. However, it is functional as per the current documentation and will be further enhanced soon.



🚀 How to Use
1.Upload the Excel file using the Browse button.
2.Click "Initial Ticket Updation".
3.The app will process the file, update tickets, and display logs.
4.A summary of successful and failed updates will be shown at the end.



⚠️ Important Guidelines
1.Follow the exact column order in the Excel file:
Ticket No. | Assigned | Estimated Time | TestCaseReviewer | ProductOwner | Contributor | CodeReviewer
2.Leave TestCaseReviewer empty for Dev tasks
3.Leave CodeReviewer empty for QA tasks



🔐 Authentication
Uses OAuth via Azure CLI to fetch access tokens.



🧾 Output
Per-ticket logs in the UI
Final count of successful and failed updates