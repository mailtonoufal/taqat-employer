using System;
using System.Collections.Generic;
using System.Text;

namespace ArabWaha.Models
{
    public class DebugDataSingleton
    {
       private static DebugDataSingleton instance;
		public static DebugDataSingleton Instance => instance ?? (instance = new DebugDataSingleton());

		/// <summary>
		/// Gets or sets the application connection identifier.
		/// </summary>
		/// <value>The application connection identifier.</value>
		public string ApplicationConnectionId { get; set; }
		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>The name of the user.</value>
		public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the basic auth.
        /// </summary>
        /// <value>The basic auth.</value>
        public string BasicAuth { get; set; }
		/// <summary>
		/// Gets or sets the nes individual identifier.
		/// </summary>
		/// <value>The nes individual identifier.</value>
		public string NesIndividualID { get; set; }
		/// <summary>
		/// Gets or sets the x smp appcid.
		/// </summary>
		/// <value>The x smp appcid.</value>
		public string X_SMP_APPCID { get; set; }
		/// <summary>
		/// Gets or sets the cookie.
		/// </summary>
		/// <value>The cookie.</value>
		public string COOKIE { get; set; }
		/// <summary>
		/// Gets or sets the x csrf token.
		/// </summary>
		/// <value>The x csrf token.</value>
		public string X_CSRF_TOKEN { get; set; }
		/// <summary>
		/// Gets or sets the sap bp individual identifier.
		/// </summary>
		/// <value>The sap bp individual identifier.</value>
		public string SapBpIndividualID { get; set; }
		/// <summary>
		/// Gets or sets the sap bp individual identifier.
		/// </summary>
		/// <value>The sap bp individual identifier.</value>
		public string Language { get; set; }
		/// <summary>
		/// Gets or sets the longitude.
		/// </summary>
		/// <value>The longitude.</value>
		public bool IsHafiz { get; set; }
		/// <summary>
		/// Gets or sets logged in users mobile no.
		/// </summary>
		/// <value>Logged in users mobile no.</value>
		public string UserMobileNumber { get; set; }
        public bool IsGuest { get; set; }
    }
}
