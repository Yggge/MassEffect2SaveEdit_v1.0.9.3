using System;
using System.Windows.Forms;

namespace Gibbed.MassEffect2.SaveEdit {
    partial class About : Form {
        public About() {
            InitializeComponent();
            this.productLabel.Text = String.Format("Mass Effect 2 Save Editor v{0} (based on Gibbed's original editor)", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }
    }

    #region ChangeLog
    /*
     * 1.0.9.2
     * BoolVariables can now be edited
     * Added notes about changing ME1 values for ME3 import
     * 
     * 1.0.9.1:
     * Fixed spectre status being shown incorrectly
     * 
     * 1.0.9.0:
     * Added about window with contributors
     * Added compare feature based on RCW's (http://social.bioware.com/project/1998/#files)
     * Added new plot variables for Tali's loyalty, Veetor'Nara, Spectre status, Maelon's data and Reaper IFF countdown
     * Allow proper import/export of face shape (lod0) and cosmetics only
     * Different head morph import/export versions handling is better
     * Facecode is now removed when needed
     * Updated head morph fun functions and added user variables to them
     * Fixed resetting of henchmen powers
     * Allow proper removal of head morph
     * Updated menu icons
     * Made bool variables read only for now
     * Changed version format
     * Added an easter egg that changes the icon based on paragon/renegade points
     * 
     * 1b8b:
     * Add missing plot value related to the destruction of the collector base
     * 
     * 1b8:
     * Changed attribution line on main editor page for better readability.
     * Updated to VS2010
     * Simplified the workaround for the Gibbed.Helpers endianness
     * Cleaned up saving, loading, exporting and importing headmorphs
     * Cleaned up the raw view and made all data available to the user
     * Added new plot values
     * Changed the application's icons
     * Export facecode along with the headmorph
     * 
     * 1b7:
     * Added updated Plots.xml from Epic Legion (fixes Conrad bug et. al.)
     * 
     * 1b6;
     * Added properties to skills tab with descriptions cross-referenced to PC Tweaks
     * 
     * 1b5:
     * Fixed saveFile endian test (was using openFileDialog r.t. saveFileDialog for path name)
     * Added warning label to skills tab that descriptions are wrong.
     */
    #endregion
}
