/*This file is used to hold any extra utility
 type stuff such as roles, statuses, etc that
we may want.*/

namespace WMF.Utility
{
    public class SD
    {
        #region User Roles
        // These are the various roles assigned to users
        public const string AdministratorRole = "Administrator";
        public const string MentorRole = "Mentor";
        public const string ManagementRole = "InternManagement"; // Guy wanted to have the intern also be management so I combined these
        public const string JudgeRole = "Judge";
        public const string ApplicantRole = "Applicant";
        public const string InternRole = "Intern";
        #endregion

        #region Application Statuses
        // These Statuses reference the status Id in the status table
        public const int StatusInProgress = 1; // This status is used when the initial application is pending submission.
        public const int StatusPendingApproval = 2; // used to show the status is waiting for the admin to either accept/approve or reject the application
        public const int StatusApproved = 3; // used to show the status is approved by the admin and is awaiting assignment to a mentor
        public const int StatusReturned = 4; // used to show the status is returned by the admin and awaiting the applicant to fix the application or withdraw it        
        public const int StatusWithdrawn = 5; // used to show that the applicant has withdrawn their application
        public const int StatusWithMentor = 6; // used to show the status is assigned to a mentor and that applicant and mentor are working toward the pitch event
        public const int StatusPitchBeingJudged = 7; // used to show that the applicant has been approved and completed the pitch event but is waiting on judges scores
        public const int StatusApprovedForFunding = 8; // used to show the applicant has been approved to receive funding
        public const int StatusArchivedRejectedClosed = 9; // used to show the status as archived/closed/rejected depending on which step it was in
        public const int StatusOneMonthFollowUp = 10; // used to show there is a 1 month followup needed
        public const int StatusThreeMonthFollowUp = 11; // used to show a 3 month followup is needed
        public const int StatusSixMonthFollowUp = 12; // used to show a 6 month followup is needed
        public const int StatusNineMonthFollowUp = 13; // used to show a 9 month followup is needed
        public const int StatusOneYearFollowUp = 14; // used to show a 1 year followup is needed
        public const int StatusEighteenMonthFollowUp = 15; // used to show an 18 month followup is needed
        public const int StatusTwoYearFollowUp = 16; // used to show a 2 year followup is needed
        public const int StatusThreeYearFollowUp = 19; // used to show a 3 year followup is needed
        public const int StatusPitchEventScheduled = 20; // This is for any pitch event when it is scheduled but not in progress
        public const int StatusPitchEventInProgress = 21; // Used for the Pitch event to show the judge is currently judging that event
        public const int StatusRackNStackPitch = 22; // Used to show that the pitch event is currently being rack/stacked for the judges - Judges cannot change scores at this point
        public const int StatusPitchOverAward = 23; // Used to show that the pitch event is over and the awards are being handed out - Judges cannot change scores at this point
        public const int StatusPitchEventArchived = 24; // Used when the pitch event is complete including awards and there is nothing to change - This event is now out of view 
                                                        // except the administrator
        #endregion

        #region Scoring Categories
        // These are statuses used for the judge score cards
        public const int ApplicationJudge = 1;
        public const int PitchJudge = 2;
        #endregion

        #region Initial Review
        // Categories used for the initial review of the application
        public const int Market = 1;
        public const int CustomersTargetMarket = 2;
        public const int Sale = 3;
        public const int Competition = 4;
        public const int Team = 5;
        #endregion

        #region Judge
        // Judge scoring categories
        public const int MarketValidation = 6;
        public const int Value = 7;
        public const int TargetCustomer = 8;
        public const int JudgeCompetition = 9;
        public const int Strategy = 10;
        public const int FinancialProjection = 11;
        public const int ManagementTeam = 12;
        public const int StatusAsk = 13;
        public const int OverallPresentation = 14;
        #endregion

        #region FileUploads
        public const int FileUploadQuestions = 7;
        #endregion

        #region Admin for Application
        public const int AdminForApplicationJudge = 113;
        #endregion
    }
}