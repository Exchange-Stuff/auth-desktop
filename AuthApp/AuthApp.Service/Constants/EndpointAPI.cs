namespace AuthApp.Service.Constants
{
    public class EndpointAPI
    {
        /// <summary>
        /// { "username": "admin",
        /// "password": "string" }
        /// </summary>
        #region Result
        /*
        {
          "value": "eyJhbYmvXvzn2zMQZ-Wdbk",
          "isSuccess": true,
          "isFailure": false,
          "error": null
        }
         */
        #endregion 
        public const string SUPER_ADMIN_LOGIN_POST = "http://localhost:5059/api/Admin/login";

        /// <summary>
        /// role?
        /// </summary>
         #region Result
        /*
        {
          "value": [
            {
              "name": "Merchant",
              "id": "26b8d4ce-7b5c-48ce-b788-5540049d08bc"
            },
            {
              "name": "Customer",
              "id": "52af75c0-b77a-4126-b8d7-b9ce54ad9bca"
            },
            {
              "name": "Admin",
              "id": "7cacea75-75cd-4d45-8fad-bd50c4757dee"
            }
          ],
          "isSuccess": true,
          "isFailure": false,
          "error": null
        }
         */
        #endregion 
        public const string PERMISSION_GROUPS_GET = "http://localhost:5059/api/Admin/permissionGroups";

        /// <summary>
        /// NO PARAM
        /// </summary>
        #region Result
        /*
        {
          "value": [
            {
              "permissionValue": 1,
              "role": null,
              "resource": null,
              "id": "3df90f14-8091-4fc9-ae93-07768138249d"
            },
            {
              "permissionValue": 15,
              "role": null,
              "resource": null,
              "id": "58b57b58-5e3b-4fb6-ab08-16d950717771"
            },
            {
              "permissionValue": 15,
              "role": null,
              "resource": null,
              "id": "ac53b49e-ec03-4be7-9944-2f0a301a6951"
            },
            {
              "permissionValue": 15,
              "role": null,
              "resource": null,
              "id": "9aa63e3a-3818-4b8d-a7ec-51f78ac402d9"
            },
            {
              "permissionValue": 15,
              "role": null,
              "resource": null,
              "id": "f54c100e-cde9-4229-abc9-d4020cb88b66"
            },
            {
              "permissionValue": 15,
              "role": null,
              "resource": null,
              "id": "36a156a0-8c1d-418e-b3ef-d6ae06e7120e"
            },
            {
              "permissionValue": 15,
              "role": null,
              "resource": null,
              "id": "104a11e1-9682-431a-af76-ee1381e2757f"
            },
            {
              "permissionValue": 15,
              "role": null,
              "resource": null,
              "id": "d342afa7-0d44-4ba3-8aa0-fd20a01d42f7"
            }
          ],
          "isSuccess": true,
          "isFailure": false,
          "error": null
        }
         */
        #endregion 
        public const string PERMISSIONS_GET = "http://localhost:5059/api/Admin/permissions";

        public const string ACTIONS_GET = "http://localhost:5059/api/Admin/actions";

        public const string PERMISSIONS_UPDATE = "http://localhost:5059/api/Admin/permissionAction/value";

        public const string USERS_GET = "http://localhost:5059/api/Account/users";

        public const string RESOURCES_GET = "http://localhost:5059/api/Admin/resources";

        public const string PERMISSION_GROUP_POST = "http://localhost:5059/api/Admin/permissionGroup/value";

        public const string PERMISSION_GROUP_RESOURCE_PUT = "http://localhost:5059/api/Admin/permissionGroup/permissions";

        public const string PERMISSION_GROUP_USER_UPDATE = "http://localhost:5059/api/Admin/accounts/permissionGroup";

        public const string ACTION_POST = "http://localhost:5059/api/Admin/action";

        public const string RESOURCE_POST = "http://localhost:5059/api/Admin/resource";

        public const string LOGOUT_POST = "http://localhost:5059/api/Admin/logout";

        public const string CREATE_ACCOUNT_POST = "http://localhost:5059/api/Admin/create/account";

        public const string ACCOUNTS_GET = "http://localhost:5059/api/Account/accounts";
    }
}
