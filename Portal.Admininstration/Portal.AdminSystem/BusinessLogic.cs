using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using HIS.Utilities.SQL.Dapper;
using Portal.AdminSystem.Models;
using Portal.AdminSystem.DataAccess;

namespace Portal.AdminSystem
{
    internal sealed class BusinessLogic
    {
        internal static string ContentConnectionString = ConfigurationManager.ConnectionStrings["ContentConnection"].ConnectionString;
        internal static string ExecCareConnectionString = ConfigurationManager.ConnectionStrings["ExecCareConnection"].ConnectionString;
        readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        ISqlConnector connector = new SqlConnector();

        internal IEnumerable<UsergroupsModel> RetrieveUsergroups()
        {
            var query = new QueryDb<UsergroupsModel>(connectionString, connector);
            return query.GetDataWithStoredProc("PortalRetrieveUsergroups", null);
        }

        internal IEnumerable<UsergroupsModel> PortalClientLists(int clientID)
        {
            var query = new QueryDb<UsergroupsModel>(connectionString, connector);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("clientID", clientID, DbType.Int32, ParameterDirection.Input, 4);
            return query.GetDataWithStoredProc("PortalClientList", parameters);
        }

        public void CreateUsergroups(UsergroupsModel usergroupsModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new CreateUsergroupsDatabaseCommand())
            {
                command.Connection = connection;
                command.SetInputParameters(usergroupsModel.Description, usergroupsModel.ClientID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        internal IEnumerable<UsergroupsModel> RetrieveUsergroupResult(UsergroupSearch usergroupSearch)
        {
            var query = new QueryDb<UsergroupsModel>(connectionString, new SqlConnector());
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("description", usergroupSearch.SearchDescription, DbType.String);
            dynamicParameters.Add("clientId", usergroupSearch.ClientId, DbType.Int32);
            string querySql = @"SELECT UserGroup.UsergroupID,UserGroup.Description, UserGroup.Priority, UserGroup.UsergroupUsageID FROM Usergroup LEFT JOIN Client_UserGroup ON UserGroup.UserGroupId = Client_UserGroup.UserGroupId";

            if (usergroupSearch.SearchDescription != null || usergroupSearch.ClientId != null) querySql += " WHERE ";

            if (usergroupSearch.SearchDescription != null) querySql = $"{querySql} Description LIKE '%' + @description + '%'";
            if (usergroupSearch.ClientId != null) querySql = $"{querySql} ClientId =  @clientId  ";

            return query.GetData(querySql, dynamicParameters);
        }

        internal IEnumerable<ClientModel> PortalRetrieveClient()
        {
            var query = new QueryDb<ClientModel>(connectionString, connector);
            return query.GetDataWithStoredProc("PortalRetrieveClient", null);
        }

        public void PortalCreateClient(ClientModel clientModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new CreateClientDatabaseCommand())
            {
                command.Connection = connection;
                command.SetInputParameters(clientModel.ClientName, clientModel.ClientMailAlias, clientModel.DisplayName);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        internal IEnumerable<ClientModel> RetrieveClientResult(ClientSearch clientSearch)
        {
            var query = new QueryDb<ClientModel>(connectionString, new SqlConnector());
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("clientName", clientSearch.SearchClientName, DbType.String);
            dynamicParameters.Add("displayName", clientSearch.SearchDisplayName, DbType.String);
            dynamicParameters.Add("clientID", clientSearch.SearchClientID, DbType.Int32);

            string querySql = @"SELECT ClientID,ClientName,DisplayName,Active,ClientMailAlias FROM Client";

            if (clientSearch.SearchClientID != null || clientSearch.SearchClientName != null || clientSearch.SearchDisplayName != null) querySql += " WHERE ";

            if (clientSearch.SearchClientID != null) querySql = $"{querySql} ClientID = @clientID AND";
            if (clientSearch.SearchClientName!= null) querySql = $"{querySql} ClientName LIKE '%' + @clientName + '%'";
            if (clientSearch.SearchDisplayName != null) querySql = $"{querySql} DisplayName Like '%' + @displayName + '%'";

            if (querySql.EndsWith("AND"))
            {
                int indexOfLastSpace = querySql.LastIndexOf("AND");
                querySql = querySql.Remove(indexOfLastSpace, 3);
            }
            return query.GetData(querySql, dynamicParameters);
        }

        internal IEnumerable<MemberModel> PortalRetrieveMembers()
        {
            var query = new QueryDb<MemberModel>(connectionString, connector);
            return query.GetDataWithStoredProc("PortalRetrieveMembers", null);
        }

        internal IEnumerable<MemberModel> PortalMemberClientList(int clientID)
        {
            var query = new QueryDb<MemberModel>(connectionString, connector);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ClientID", clientID, DbType.Int32, ParameterDirection.Input, 4);
            return query.GetDataWithStoredProc("PortalClientList", parameters);
        }

        internal IEnumerable<MemberModel> PortalMemberUsergroupList(int clientID)
        {
            var query = new QueryDb<MemberModel>(connectionString, connector);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ClientID", clientID, DbType.Int32, ParameterDirection.Input, 4);
            return query.GetDataWithStoredProc("PortalUsergroupByID", parameters);
        }

        public void PortalCreateMember(MemberModel memberModel)
        {

            using (var connection = new SqlConnection(connectionString))
            using (var command = new CreateMemberDatabaseCommand())
            {
                command.Connection = connection;
                command.SetInputParameters(memberModel.Email, memberModel.Username, memberModel.Name, memberModel.Surname, memberModel.ClientID, memberModel.UsergroupID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        internal IEnumerable<MemberModel> RetrieveSearchMemberResult(MemberSearch memberSearch)
        {
            var query = new QueryDb<MemberModel>(connectionString, new SqlConnector());
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("email", memberSearch.SearchEmail, DbType.String);
            dynamicParameters.Add("name", memberSearch.SearchName, DbType.String);
            dynamicParameters.Add("surname", memberSearch.SearchSurname, DbType.String);

            string querySql = @"SELECT m.MemberID, m.ClientID, m.Name, m.Surname, m.Username, m.Email, m.Active,
                                c.ClientName, g.Description From Members m
                                INNER JOIN Client c on m.ClientID = c.ClientID
                                INNER JOIN Member_Usergroup mu on m.MemberID = mu.MemberID
                                INNER JOIN Usergroup g on mu.UserGroupID = g.UsergroupID";

            if  (memberSearch.SearchEmail != null || memberSearch.SearchName != null || memberSearch.SearchSurname != null ) querySql += " WHERE ";

            if (memberSearch.SearchEmail != null) querySql = $"{querySql} Email LIKE '%' + @email + '%' AND";
            if (memberSearch.SearchName != null) querySql = $"{querySql} Name LIKE '%' + @name + '%' AND";
            if (memberSearch.SearchSurname != null) querySql = $"{querySql} Surname Like '%' + @surname + '%'";

            if (querySql.EndsWith("AND"))
            {
                int indexOfLastSpace = querySql.LastIndexOf("AND");
                querySql = querySql.Remove(indexOfLastSpace, 3);
            }
            return query.GetData(querySql, dynamicParameters);
        }

        internal IEnumerable<IcasConnect> PortalRetrieveIcasConnect()
        {
            var query = new QueryDb<IcasConnect>(ContentConnectionString, connector);
            return query.GetDataWithStoredProc("PortalRetrieveIcasConnect", null);
        }

        public void PortalAboutIcasConnect(IcasConnect icasConnect)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new CreateIcasConnectDatabaseCommand())
            {
                command.Connection = connection;
                command.SetInputParameters(icasConnect.ClientID, icasConnect.ClientName);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        internal IEnumerable<IcasConnect> PortalIcasConnect(int clientID)
        {
            var query = new QueryDb<IcasConnect>(connectionString, connector);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ClientID ", clientID, DbType.Int32, ParameterDirection.Input, 4);
            return query.GetDataWithStoredProc("PortalIcasConnect", parameters);
        }

        internal IEnumerable<IcasConnect> RetrieveIcasConnectResult(IcasConnectSearch icasConnectSearch)
        {
            var query = new QueryDb<IcasConnect>(connectionString, new SqlConnector());
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("clientName", icasConnectSearch.SearchClientname, DbType.String);
            dynamicParameters.Add("pDFName", icasConnectSearch.SearchPDFName, DbType.String);

            string querySql = @"SELECT ClientName, PDFName, ClientID FROM [GlobalPortalContent].[dbo].[tblMenuPDF]";

            if (icasConnectSearch.SearchClientname != null || icasConnectSearch.SearchPDFName != null) querySql += " WHERE ";

            if (icasConnectSearch.SearchClientname != null) querySql = $"{querySql} ClientName LIKE '%' + @clientName + '%' AND";
            if (icasConnectSearch.SearchPDFName != null) querySql = $"{querySql} PDFName LIKE '%' + @pDFName + '%'";

            if (querySql.EndsWith("AND"))
            {
                int indexOfLastSpace = querySql.LastIndexOf("AND");
                querySql = querySql.Remove(indexOfLastSpace, 3);
            }
            return query.GetData(querySql, dynamicParameters);
        }

        internal IEnumerable<ExecPackageAppointment> ExecAppointmentTypesList(int typeID)
        {
            var query = new QueryDb<ExecPackageAppointment>(ExecCareConnectionString, connector);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("TypeID", typeID, DbType.Int32, ParameterDirection.Input, 4);
            return query.GetDataWithStoredProc("PortalSelectType", parameters);
        }

        internal IEnumerable<ExecPackageAppointment> ExecSelectPackage(int id)
        {
            var query = new QueryDb<ExecPackageAppointment>(ExecCareConnectionString, connector);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int32, ParameterDirection.Input, 4);
            return query.GetDataWithStoredProc("PortalSelectPackage", parameters);
        }

        internal IEnumerable<ExecPackageAppointment> RetrieveAppointment()
        {
            var query = new QueryDb<ExecPackageAppointment>(ExecCareConnectionString, connector);
            return query.GetDataWithStoredProc("PortalRetrieveAppointment", null);
        }

        public void CreateAppointMent(ExecPackageAppointment execPackageAppointment)
        {
            using (var connection = new SqlConnection(ExecCareConnectionString))
            using (var command = new CreateExecAppointment())
            {
                command.Connection = connection;
                command.SetInputParameters(execPackageAppointment.PackageID, execPackageAppointment.TypeID, execPackageAppointment.MinutesOfAppointment);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
     
        internal IEnumerable<ExecBookingModel> ExecCareRetrieveCalender()
        {
            var query = new QueryDb<ExecBookingModel>(ExecCareConnectionString, connector);
            return query.GetDataWithStoredProc("PortalRetrieveCalender", null);
        }

        internal IEnumerable<ExecBookingModel> RetriveBookingResults(SearchBooking searchBooking)
        {
            var query = new QueryDb<ExecBookingModel>(ExecCareConnectionString, new SqlConnector());
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("subject", searchBooking.SearchSubject, DbType.String);
            dynamicParameters.Add("memberID", searchBooking.SearchMemberID, DbType.String);

            string querySql = @"SELECT ID,MemberID, Subject, StartDateTime, EndDateTime, Deleted FROM [dbo].[ExecCareCalander]";

            if (searchBooking.SearchSubject != null || searchBooking.SearchMemberID != null) querySql += " WHERE ";

            if (searchBooking.SearchSubject != null) querySql = $"{querySql} Subject LIKE '%' + @subject + '%' AND";
            if (searchBooking.SearchMemberID != null) querySql = $"{querySql} MemberID LIKE '%' + @memberID + '%'";

            if (querySql.EndsWith("AND"))
            {
                int indexOfLastSpace = querySql.LastIndexOf("AND");
                querySql = querySql.Remove(indexOfLastSpace, 3);
            }
            return query.GetData(querySql, dynamicParameters);
        }

        internal IEnumerable<ExecUsersModel> RetrieveExecUsers()
        {
            var query = new QueryDb<ExecUsersModel>(ExecCareConnectionString, connector);
            return query.GetDataWithStoredProc("PortalRetriveExecUsers", null);
        }

        internal IEnumerable<ExecUsersModel> ExecCareUserRegionLists(int execRegionID)
        {
            var query = new QueryDb<ExecUsersModel>(ExecCareConnectionString, connector);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ExecRegionID", execRegionID, DbType.Int32, ParameterDirection.Input, 4);
            return query.GetDataWithStoredProc("PortalSelectRegion", parameters);
        }

        internal IEnumerable<ExecUsersModel> ExecCareUserTypesLists(int typeID)
        {
            var query = new QueryDb<ExecUsersModel>(ExecCareConnectionString, connector);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("TypeID", typeID, DbType.Int32, ParameterDirection.Input, 4);
            return query.GetDataWithStoredProc("PortalSelectType", parameters);
        }

        public void CreateExecUserLogin(ExecUsersModel  execUsersModel)
        {
            using (var connection = new SqlConnection(ExecCareConnectionString))
            using (var command = new CreateExecCareUsersDatabaseCommand())
            {
                command.Connection = connection;
                command.SetInputParameters(execUsersModel.ExecName, execUsersModel.ExecSurname, execUsersModel.ExecEmail, execUsersModel.ExecPassword, execUsersModel.TypeID, execUsersModel.ExecRegionID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        internal IEnumerable<ExecUsersModel> RetrieveSearchExecResult(SearchExecUsers searchExecUsers)
        {
            var query = new QueryDb<ExecUsersModel>(ExecCareConnectionString, new SqlConnector());
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("email", searchExecUsers.SearchEmail, DbType.String);
            dynamicParameters.Add("name", searchExecUsers.SearchName, DbType.String);
            dynamicParameters.Add("surname", searchExecUsers.SearchSurname, DbType.String);

            string querySql = @"SELECT ExecUserID,ExecName,ExecSurname,ExecUsername,ExecPassword,ExecEmail,Active, TypeID, IsDefault FROM ExecCareUsers";

            if (searchExecUsers.SearchEmail != null || searchExecUsers.SearchName != null || searchExecUsers.SearchSurname != null) querySql += " WHERE ";

            if (searchExecUsers.SearchEmail != null) querySql = $"{querySql} ExecEmail LIKE '%' + @email + '%' AND";
            if (searchExecUsers.SearchName != null) querySql = $"{querySql} ExecName LIKE '%' + @name + '%' AND";
            if (searchExecUsers.SearchSurname != null) querySql = $"{querySql} ExecSurname LIKE '%' + @surname + '%'";

            if (querySql.EndsWith("AND"))
            {
                int indexOfLastSpace = querySql.LastIndexOf("AND");
                querySql = querySql.Remove(indexOfLastSpace, 3);
            }
            return query.GetData(querySql, dynamicParameters);
        }

        internal IEnumerable<ExecCarePackagesModel> PortalStreamList(int stream)
        {
            var query = new QueryDb<ExecCarePackagesModel>(ExecCareConnectionString, connector);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Stream", stream, DbType.Int32, ParameterDirection.Input, 4);
            return query.GetDataWithStoredProc("PortalSelectStream", parameters);
        }

        internal IEnumerable<ExecCarePackagesModel> PortalRetrieveExecPackages()
        {
            var query = new QueryDb<ExecCarePackagesModel>(ExecCareConnectionString, connector);
            return query.GetDataWithStoredProc("PortalRetrivePackages", null);
        }

        public void CreateExecPackage(ExecCarePackagesModel execCarePackagesModel)
        {
            using (var connection = new SqlConnection(ExecCareConnectionString))
            using (var command = new CreateExecPackageDatabaseCommand())
            {
                command.Connection = connection;
                command.SetInputParameters(execCarePackagesModel.Description, execCarePackagesModel.Stream);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        internal IEnumerable<ExecCarePackagesModel> RetrievePackageResult(SearchExecPackage searchExecPackage)
        {
            var query = new QueryDb<ExecCarePackagesModel>(ExecCareConnectionString, new SqlConnector());
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("description", searchExecPackage.SearchDescription, DbType.String);  

            string querySql = @"SELECT ID,Description,Color,Stream,Active FROM ExecCarePackages";

            if (searchExecPackage.SearchDescription != null) querySql += " WHERE ";

            if (searchExecPackage.SearchDescription != null) querySql = $"{querySql} Description LIKE '%' + @description + '%'";
        
            return query.GetData(querySql, dynamicParameters);
        }

        internal IEnumerable<ExecMemberRegisterModel> PortalRetrieveExecMembers()
        {
            var query = new QueryDb<ExecMemberRegisterModel>(ExecCareConnectionString, connector);
            return query.GetDataWithStoredProc("PortalExecRetrieveMembers", null);
        }

        internal IEnumerable<ExecClientUsergroups> PortalRetrieveExecClientUsergrops()
        {
            var query = new QueryDb<ExecClientUsergroups>(ExecCareConnectionString, connector);
            return query.GetDataWithStoredProc("PortalExecRetrieveClientUsergroups", null);
        }

        public void CreateExecClientUsergroups(ExecClientUsergroups execClientUsergroups)
        {
            using (var connection = new SqlConnection(ExecCareConnectionString))
            using (var command = new CreateExecClientDatabaseCommand())
            {
                command.Connection = connection;
                command.SetInputParameters(execClientUsergroups.Description);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        internal IEnumerable<ExecClientUsergroups> RetrieveExecClientUsergroupResults(SearchExecClient searchExecClient)
        {
            var query = new QueryDb<ExecClientUsergroups>(ExecCareConnectionString, new SqlConnector());
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("description", searchExecClient.SearchDescription, DbType.String);

            string querySql = @"SELECT UsergroupID, Description, TrialPeriod, Priority, Principal FROM Usergroup";

            if (searchExecClient.SearchDescription != null) querySql += " WHERE ";

            if (searchExecClient.SearchDescription != null) querySql = $"{querySql} Description LIKE '%' + @description + '%'";

            return query.GetData(querySql, dynamicParameters);
        }

        internal IEnumerable<ExecMemberRegisterModel> RetrieveExecCareMemberResult(ExecMemberSearch execMemberSearch)
        {
            var query = new QueryDb<ExecMemberRegisterModel>(ExecCareConnectionString, new SqlConnector());
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("name", execMemberSearch.SearchName, DbType.String);
            dynamicParameters.Add("surname", execMemberSearch.SearchSurname, DbType.String);

            string querySql = @"SELECT r.ID,r.ExecPackageID,r.ExecRegionID,r.StatusID,m.MemberID,m.Name, m.Surname, m.ClientID, u.Description From Members AS m 
                               INNER JOIN ExecCareMemberRegister AS r ON m.MemberID = r.MemberID
                               INNER JOIN memberusergroup AS g ON m.MemberID = g.MemberID
                               INNER JOIN  Usergroup AS u ON g.UsergroupID = u.UsergroupID";

            if (execMemberSearch.SearchName != null || execMemberSearch.SearchSurname != null) querySql += " WHERE ";

            if (execMemberSearch.SearchName != null) querySql = $"{querySql} Name LIKE '%' + @name + '%' AND";
            if (execMemberSearch.SearchSurname != null) querySql = $"{querySql} Surname LIKE '%' + @surname + '%'";

            if (querySql.EndsWith("AND"))
            {
                int indexOfLastSpace = querySql.LastIndexOf("AND");
                querySql = querySql.Remove(indexOfLastSpace, 3);
            }
            return query.GetData(querySql, dynamicParameters);
        }

        internal IEnumerable<ClientPage> ClientPageResults(SearchPage searchPage)
        {
            var query = new QueryDb<ClientPage>(connectionString, new SqlConnector());
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("clientname", searchPage.SearchClientName, DbType.String);

            string querySql = @"Select Client.ClientID, Client.ClientName, Client_PageTemplate.PageTemplateType_LinkID, Client_PageTemplate.ClientSettingID From Client
                                Inner JOIN Client_PageTemplate ON Client.ClientID = Client_PageTemplate.ClientID";

            if (searchPage.SearchClientName != null ) querySql += " WHERE ";

            if (searchPage.SearchClientName != null) querySql = $"{querySql} Clientname LIKE '%' + @clientname + '%'";
     
            return query.GetData(querySql, dynamicParameters);
        }

        internal IEnumerable<ClientWelcomeModel> ClientWelcomeResults(SearchWelcome searchWelcome)
        {
            var query = new QueryDb<ClientWelcomeModel>(connectionString, new SqlConnector());
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("clientname", searchWelcome.SearchClientname, DbType.String);

            string querySql = @"SELECT t.Template_ClientID,t.TemplateID,t.ClientID, c.Color,c.TemplateClientID,c.ClientColorID, d.Clientname
                              FROM [dbo].[TblWelcomeTemplate_Client] t
                              INNER  JOIN [dbo].[TblWelcome_ClientColor] c on t.Template_ClientID = c.TemplateClientID 
                              INNER JOIN dbo.Client d on t.ClientID = d.ClientID";

            if (searchWelcome.SearchClientname != null) querySql += " WHERE ";

            if (searchWelcome.SearchClientname != null) querySql = $"{querySql} Clientname LIKE '%' + @clientname + '%'";

            return query.GetData(querySql, dynamicParameters);
        }

        public void CreateClientWelcome(ClientWelcomeModel clientWelcomeModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new CreateClientwelcomeDBCommand())
            {
                command.Connection = connection;
                command.SetInputParameters(clientWelcomeModel.ClientID, clientWelcomeModel.TemplateID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        internal IEnumerable<ClientWelcomeModel> PortalPageClientLists(int clientID)
        {
            var query = new QueryDb<ClientWelcomeModel>(connectionString, connector);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("clientID", clientID, DbType.Int32, ParameterDirection.Input, 4);
            return query.GetDataWithStoredProc("PortalClientList", parameters);
        }

        internal IEnumerable<ClientWelcomeModel> PortalTemplatesList(int tempelateID)
        {
            var query = new QueryDb<ClientWelcomeModel>(connectionString, connector);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("TempelateID", tempelateID, DbType.Int32, ParameterDirection.Input, 4);
            return query.GetDataWithStoredProc("PortalGetTemplates", parameters);
        }

        internal IEnumerable<WelcomeSubjectModel> SubjectResults(SearchWelcomeSubject searchWelcomeSubject)
        {
            var query = new QueryDb<WelcomeSubjectModel>(connectionString, new SqlConnector());
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("subject", searchWelcomeSubject.SearchSubject, DbType.String);

            string querySql = @"SELECT TemplateID, Subject, DateCreate FROM TblWelcomeTemplates";

            if (searchWelcomeSubject.SearchSubject != null) querySql += " WHERE ";

            if (searchWelcomeSubject.SearchSubject != null) querySql = $"{querySql} Subject LIKE '%' + @subject + '%'";

            return query.GetData(querySql, dynamicParameters);
        }

        public void CreateSubjectWelcome(WelcomeSubjectModel welcomeSubjectModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new CreateSubjectWelcomeDBCommand())
            {
                command.Connection = connection;
                command.SetInputParameters(welcomeSubjectModel.Subject);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
  }
  
