namespace AuthApp.Service.Constants
{
    /// <summary>
    /// Now lookeach ROLE <=> PERMISSION GROUP,(Role doesn't mean Role, Role here is group permission)
    /// No header param in heere
    /// </summary>
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
        public const string SUPER_ADMIN_LOGIN_POST = "http://localhost:5188/api/SuperAdmin/login";

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
        public const string PERMISSION_GROUP_GET = "http://localhost:5188/api/SuperAdmin/roles";


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
              "id": "d342afa7-0d44-4ba3-8aa0-fd20a01d42f7"
            }
          ],
          "isSuccess": true,
          "isFailure": false,
          "error": null
        }
         */
        #endregion 
        public const string PERMISSION_GET = "http://localhost:5188/api/SuperAdmin/permissions";

        public const string ACTIONS_GET = "http://localhost:5188/api/SuperAdmin/actions";

        public const string PERMISSIONS_UPDATE_RANGE = "http://localhost:5188/api/SuperAdmin/permissions";
    }
}
