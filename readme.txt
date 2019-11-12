Mass Effect 2 Save Editor v1.0.9.3

This is a modified version of Gibbed's original ME2 editor for the PC (http://www.gib.me).
It has several bugs fixed, provides access to many more plot variables, allows partial head morph exports (eg. cosmetics only) and has a savefile compare feature. 

Changelog:

============================
Notes for 11/3/2012 v1.0.9.2

BoolVariables can now be edited
Added notes about changing ME1 values for ME3 import


============================
Notes for 10/3/2012 v1.0.9.1

Fixed spectre status being shown incorrectly


============================
Notes for 8/3/2012 v1.0.9.0

Added new plot variables for Tali's loyalty, Veetor'Nara, Spectre status, Maelon's data and Reaper IFF countdown trigger
Added import/export for partial head morphs (eg. cosmetics only)
Added customizable settings for head morph fun functions
Added raw compare feature based on RCW's editor
Added an about window with a list of contributors
Character facecode (if any) is now exported with full head morphs
Fixed resetting of henchmen powers


===========================================
Notes for 2/3/2012 r1b8b (v1.0.8.1)

Added a missing plot value related to the destruction of the collector base


===========================================
Notes for 1/3/2012 r1b8 (v1.0.8.0)

Added more ME2 plots to the plot table (inc. state of the crew after suicide mission)
Added Research and Mission Rewards tab under the plot tab
Some general UI cleanup (main window is now scalable)


===========================================
Notes for 28/4/2011 r1b7

Added ME2 plot table to the plots tab. Should fix Conrad Verner bug et. al.
(Thanks goes to Epic Legion for giving me this fix!)


===========================================
Notes for 26/4/2011 r1b6

Organized and changed descriptions on Skills tab for everything that seemed of interest by cross-referencing descriptions at PC Tweaks [http://masseffect.wikia.com/wiki/PC_Tweaks_(Mass_Effect_2)] with the bin/me2_plot_variables.csv file from Gibbed source.
Descriptions for values are from suggestions at PC Tweaks. It may be useful to enter values outside the stated range for some things. See the mod thread on editing at http://social.bioware.com/forum/1/topic/128/index/2277020/1 for more information.


===========================================
Notes for 20/4/2011 r1b5

Bug fix. I fixed a problem with the file save that might affect 
xbox <--> pc cross-saving.  It shouldn't affect xbox->xbox or pc->pc.

Added warning label to Skills/Upgrade tab that the usage descriptions are 
*wrong* at least in some places.


===========================================
Notes for 19/4/2011 r1b4

I have added all of NuTitan's variables to a new tab Player->Skills/Upgrades.  The IntVariables array is still also there. (This is a somewhat more organized copy of the raw tab ME2 plot table.)


===========================================
Notes for 5/4/2011 r1b3

The significant changes are:

1. The editor will read/write either pcsav or xbsav files. This also makes the "New Male" and "New Female" menu items work for the xbox version (since the resources were stored in the pc format--at least in the version I had.)
N.B.: Because of this decision, I have changed the Headmorph output for the Xbox version to make *all* Headmorphs little-endian and thus interchangeable between the pc and xbox save games.  As a result, older xbox Headmorphs will cause an import message stating that the file appears to be in Big-Endian format and asking if you want to proceed.
(Note: this will *not* allow xbsavs to inherit all the modding capability of the pc game---that is still limited by what is included in the save game.)
2. I have added some game save information to the main screen: Notably some location information (not yet expanded from the save game acronym-like form at this time), Time played, and Last Played time.
3. I have created a menu item for the toolbox headmorph import/export (it's still in the toolbox, also).
4. Oh yeah. I changed the strings to use windows default encoding so it would quit removing the accented characters in my name.

The following are available only because I was playing around with them. They are not completed features.
A. The toolbox had a LOD0 button to export the LOD0 points to a file in string format (triples of x, y, z). Export only at this time.
B. The ME2 Plot in the raw tab has access to some previously unmapped variables (some of which have now been discovered). I have also included raw access to an integer array that contains these new items (all I think).  NuTitan's offsets translate into the integer array as (offset/4)+3.

My next task is to place the newly mapped items in a more accessible location. (E.g. the weapons ammo counts, dmg, etc.)


===========================================
Notes for 15/2/2010 XandorChaos' version
