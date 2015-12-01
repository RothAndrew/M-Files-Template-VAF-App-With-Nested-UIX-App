using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFiles.VAF;
using MFiles.VAF.Common;
using MFilesAPI;
using System.IO;

namespace $safeprojectname$
{
    /// <summary>
    /// Simple vault application to demonstrate VAF.
    /// </summary>
    public class VaultApplication : VaultApplicationBase
    {
        /// <summary>
        /// Install nested UX App via API if not already installed
        /// </summary>
        /// <param name="vault"></param>
        protected override void InitializeApplication(Vault vault)
        {
            try
            {
                string appPath = "Nested UIX App.zip";
                if (File.Exists(appPath))
                {
                    vault.CustomApplicationManagementOperations.InstallCustomApplication(appPath);
                }
                else
                {
                    SysUtils.ReportErrorToEventLog("File: " + appPath + " does not exist");
                }
            }
            catch (Exception ex)
            {
                SysUtils.ReportErrorToEventLog(ex.Message);
            }

            base.InitializeApplication(vault);
        }

        /// <summary>
        /// A vault extension method, that will be installed to the vault with the application.
        /// The vault extension method can be called through the API.
        /// </summary>
        /// <param name="env">The event handler environment for the method.</param>
        /// <returns>The output string to the caller.</returns>
        [VaultExtensionMethod("GetMessageForNestedUIXApp_$safeprojectname$", RequiredVaultAccess = MFVaultAccess.MFVaultAccessNone)]
        private string GetMessageForNestedUIXApp(EventHandlerEnvironment env)
        {
            // Return the input and the alias and id of the test class. If the class is missing, ID is -1.
            return "Hello! I'm from the extension method! Here's the input you gave me: " + env.Input;
        }
    }
}