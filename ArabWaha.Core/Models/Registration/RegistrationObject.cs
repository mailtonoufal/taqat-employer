using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha.Models
{
    public class RegistrationObject
    {
		public string ETag { get; set; }
		public string ApplicationConnectionId { get; set; }
		public string UserName { get; set; }
		public bool AndroidGcmPushEnabled { get; set; }
		public string AndroidGcmRegistrationId { get; set; }
		public string AndroidGcmSenderId { get; set; }
		public bool ApnsPushEnable { get; set; }
		public string ApnsDeviceToken { get; set; }
		public string ApplicationVersion { get; set; }
		public string BlackberryPushEnabled { get; set; }
		public string BlackberryDevicePin { get; set; }
		public int BlackberryBESListenerPort { get; set; }
		public string BlackberryPushAppID { get; set; }
		public string BlackberryPushBaseURL { get; set; }
		public int BlackberryPushListenerPort { get; set; }
		public int BlackberryListenerType { get; set; }
		public bool CollectClientUsageReports { get; set; }
		public string ConnectionLogLevel { get; set; }
		public string CustomizationBundleId { get; set; }
		public string CustomCustom1 { get; set; }
		public string CustomCustom2 { get; set; }
		public string CustomCustom3 { get; set; }
		public string CustomCustom4 { get; set; }
		public string DeviceModel { get; set; }
		public string DeviceType { get; set; }
		public string DeviceSubType { get; set; }
		public string DevicePhoneNumber { get; set; }
		public string DeviceIMSI { get; set; }
		public string E2ETraceLevel { get; set; }
		public bool EnableAppSpecificClientUsageKeys { get; set; }
		public bool FeatureVectorPolicyAllEnabled { get; set; }
		public string FormFactor { get; set; }
		public int LogEntryExpiry { get; set; }
		public int MaxConnectionWaitTimeForClientUsage { get; set; }
		public string MpnsChannelURI { get; set; }
		public bool MpnsPushEnable { get; set; }
		public bool PasswordPolicyEnabled { get; set; }
		public bool PasswordPolicyDefaultPasswordAllowed { get; set; }
		public int PasswordPolicyMinLength { get; set; }
		public bool PasswordPolicyDigitRequired { get; set; }
		public bool PasswordPolicyUpperRequired { get; set; }
		public bool PasswordPolicyLowerRequired { get; set; }
		public bool PasswordPolicySpecialRequired { get; set; }
		public int PasswordPolicyExpiresInNDays { get; set; }
		public int PasswordPolicyMinUniqueChars { get; set; }
		public int PasswordPolicyLockTimeout { get; set; }
		public int PasswordPolicyRetryLimit { get; set; }
		public bool PasswordPolicyFingerprintEnabled { get; set; }
		public string ProxyApplicationEndpoint { get; set; }
		public string ProxyPushEndpoint { get; set; }
		public bool PublishedToMobilePlace { get; set; }
		public bool UploadLogs { get; set; }
		public string WnsChannelURI { get; set; }
		public bool WnsPushEnable { get; set; }
		public bool InAppMessaging { get; set; }
		public string UserLocale { get; set; }
		public string TimeZone { get; set; }
		public string LastKnownLocation { get; set; }
		public DateTime CreatedAt { get; set; }
		public string PushGroup { get; set; }
		public string Email { get; set; }
		public Capability Capability { get; set; }
		public FeatureVectorPolicy FeatureVectorPolicy { get; set; }
    }

	public class Capability
	{
		public List<object> results { get; set; }
	}

	public class FeatureVectorPolicy
	{
		public List<object> results { get; set; }
	}
}
