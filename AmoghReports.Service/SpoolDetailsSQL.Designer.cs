﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmoghReports.Service {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SpoolDetailsSQL {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SpoolDetailsSQL() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AmoghReports.Service.SpoolDetailsSQL", typeof(SpoolDetailsSQL).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT
        ///     PROJ.PROJECT_ID,
        ///     PROJ.JOB_CODE,
        ///     PROJ.CLIENT_NAME,
        ///     PROJ.JOB_NAME,
        ///     PROJ.APP_LOGO1,
        ///     PROJ.APP_LOGO2,
        ///     PROJ.REMARKS                             AS PROJ_REM,
        ///     PIP_ISOMETRIC.ISO_ID,
        ///     PIP_ISOMETRIC.AREA_L1,
        ///     IPMS_AREA.AREA_L2,
        ///     IPMS_AREA.AREA_GROUP,
        ///     PIP_ISOMETRIC.UNIT,
        ///     PIP_ISOMETRIC.AGUG,
        ///     PIP_ISOMETRIC.ISO_TITLE1,
        ///     PIP_ISOMETRIC.FLUID_CODE,
        ///     NVL(VIEW_WO_SPL_ID.SUB_CON_ID,SUBCON.SUB_CON_ID) AS SUB_CON_ID,
        ///     NVL(VIEW_W [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SpoolDetailSQL_A {
            get {
                return ResourceManager.GetString("SpoolDetailSQL_A", resourceCulture);
            }
        }
    }
}
