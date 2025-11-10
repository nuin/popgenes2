/*
 * MATLAB Compiler: 4.3 (R14SP3)
 * Date: Tue Jan 12 18:09:07 2010
 * Arguments: "-B" "macro_default" "-m" "-W" "main" "-T" "link:exe"
 * "quantitative_trait.m" "-o" "qtl" 
 */

#include "mclmcr.h"

#ifdef __cplusplus
extern "C" {
#endif
const unsigned char __MCC_qtl_session_key[] = {
        '4', '9', 'A', '9', '7', 'E', '2', 'B', 'B', '5', '3', '1', '0', 'E',
        '0', '1', '0', 'C', '2', 'A', '6', '8', 'F', '6', 'E', '0', '4', 'B',
        'A', '5', '6', '9', 'F', 'E', '0', '0', '5', '9', '2', '6', 'D', '8',
        '5', '5', 'A', 'F', 'C', '8', '1', '4', '2', 'F', 'E', 'E', 'A', '1',
        'D', 'F', 'A', 'D', '4', 'D', '4', '1', 'F', 'D', '6', '3', '9', '2',
        'F', '4', '2', '8', '6', '5', '3', '9', '7', '1', '4', 'A', 'C', 'A',
        '9', 'C', 'D', '7', '1', 'C', 'A', '2', 'B', '4', '8', '3', '5', 'C',
        '4', '8', '2', '8', '7', 'C', '7', '6', '4', '6', '2', 'B', 'E', 'C',
        '2', 'F', 'D', 'B', 'A', 'A', '9', 'E', 'A', '1', '0', '1', '0', '5',
        'F', 'D', '6', '3', '4', 'F', '5', 'B', 'C', '7', '1', '8', '8', '9',
        '5', '1', '7', 'C', '9', '1', '0', 'E', '0', '7', 'E', 'E', 'E', '4',
        'B', '5', '6', '3', '8', '5', '7', 'C', '7', 'D', '6', '0', '2', '5',
        'C', '3', '3', 'B', '2', '0', '5', '9', 'E', 'F', '5', '0', '4', '0',
        '5', '1', 'D', '9', 'F', '3', '9', '1', '2', 'A', '7', '9', '9', 'F',
        '1', '1', '3', '7', '1', '7', '2', '0', '0', '2', '0', 'E', '1', '8',
        '1', '7', 'F', '3', 'E', '1', 'C', 'A', '7', '4', '0', '3', 'E', '5',
        '9', '8', 'E', 'D', 'E', 'D', '1', '2', '0', '2', '0', '9', 'B', 'D',
        '7', '1', 'C', 'A', '3', '1', 'B', '8', 'C', 'A', '0', '5', '4', '3',
        '4', '3', '4', '3', '\0'};

const unsigned char __MCC_qtl_public_key[] = {
        '3', '0', '8', '1', '9', 'D', '3', '0', '0', 'D', '0', '6', '0', '9',
        '2', 'A', '8', '6', '4', '8', '8', '6', 'F', '7', '0', 'D', '0', '1',
        '0', '1', '0', '1', '0', '5', '0', '0', '0', '3', '8', '1', '8', 'B',
        '0', '0', '3', '0', '8', '1', '8', '7', '0', '2', '8', '1', '8', '1',
        '0', '0', 'C', '4', '9', 'C', 'A', 'C', '3', '4', 'E', 'D', '1', '3',
        'A', '5', '2', '0', '6', '5', '8', 'F', '6', 'F', '8', 'E', '0', '1',
        '3', '8', 'C', '4', '3', '1', '5', 'B', '4', '3', '1', '5', '2', '7',
        '7', 'E', 'D', '3', 'F', '7', 'D', 'A', 'E', '5', '3', '0', '9', '9',
        'D', 'B', '0', '8', 'E', 'E', '5', '8', '9', 'F', '8', '0', '4', 'D',
        '4', 'B', '9', '8', '1', '3', '2', '6', 'A', '5', '2', 'C', 'C', 'E',
        '4', '3', '8', '2', 'E', '9', 'F', '2', 'B', '4', 'D', '0', '8', '5',
        'E', 'B', '9', '5', '0', 'C', '7', 'A', 'B', '1', '2', 'E', 'D', 'E',
        '2', 'D', '4', '1', '2', '9', '7', '8', '2', '0', 'E', '6', '3', '7',
        '7', 'A', '5', 'F', 'E', 'B', '5', '6', '8', '9', 'D', '4', 'E', '6',
        '0', '3', '2', 'F', '6', '0', 'C', '4', '3', '0', '7', '4', 'A', '0',
        '4', 'C', '2', '6', 'A', 'B', '7', '2', 'F', '5', '4', 'B', '5', '1',
        'B', 'B', '4', '6', '0', '5', '7', '8', '7', '8', '5', 'B', '1', '9',
        '9', '0', '1', '4', '3', '1', '4', 'A', '6', '5', 'F', '0', '9', '0',
        'B', '6', '1', 'F', 'C', '2', '0', '1', '6', '9', '4', '5', '3', 'B',
        '5', '8', 'F', 'C', '8', 'B', 'A', '4', '3', 'E', '6', '7', '7', '6',
        'E', 'B', '7', 'E', 'C', 'D', '3', '1', '7', '8', 'B', '5', '6', 'A',
        'B', '0', 'F', 'A', '0', '6', 'D', 'D', '6', '4', '9', '6', '7', 'C',
        'B', '1', '4', '9', 'E', '5', '0', '2', '0', '1', '1', '1', '\0'};

static const char * MCC_qtl_matlabpath_data[] = 
    { "qtl/", "toolbox/compiler/deploy/",
      "$TOOLBOXMATLABDIR/general/", "$TOOLBOXMATLABDIR/ops/",
      "$TOOLBOXMATLABDIR/lang/", "$TOOLBOXMATLABDIR/elmat/",
      "$TOOLBOXMATLABDIR/elfun/", "$TOOLBOXMATLABDIR/specfun/",
      "$TOOLBOXMATLABDIR/matfun/", "$TOOLBOXMATLABDIR/datafun/",
      "$TOOLBOXMATLABDIR/polyfun/", "$TOOLBOXMATLABDIR/funfun/",
      "$TOOLBOXMATLABDIR/sparfun/", "$TOOLBOXMATLABDIR/scribe/",
      "$TOOLBOXMATLABDIR/graph2d/", "$TOOLBOXMATLABDIR/graph3d/",
      "$TOOLBOXMATLABDIR/specgraph/", "$TOOLBOXMATLABDIR/graphics/",
      "$TOOLBOXMATLABDIR/uitools/", "$TOOLBOXMATLABDIR/strfun/",
      "$TOOLBOXMATLABDIR/imagesci/", "$TOOLBOXMATLABDIR/iofun/",
      "$TOOLBOXMATLABDIR/audiovideo/", "$TOOLBOXMATLABDIR/timefun/",
      "$TOOLBOXMATLABDIR/datatypes/", "$TOOLBOXMATLABDIR/verctrl/",
      "$TOOLBOXMATLABDIR/codetools/", "$TOOLBOXMATLABDIR/helptools/",
      "$TOOLBOXMATLABDIR/winfun/", "$TOOLBOXMATLABDIR/demos/",
      "$TOOLBOXMATLABDIR/timeseries/", "$TOOLBOXMATLABDIR/hds/",
      "toolbox/local/", "toolbox/compiler/", "toolbox/stats/" };

static const char * MCC_qtl_classpath_data[] = 
    { "" };

static const char * MCC_qtl_libpath_data[] = 
    { "" };

static const char * MCC_qtl_app_opts_data[] = 
    { "" };

static const char * MCC_qtl_run_opts_data[] = 
    { "" };

static const char * MCC_qtl_warning_state_data[] = 
    { "" };


mclComponentData __MCC_qtl_component_data = { 

    /* Public key data */
    __MCC_qtl_public_key,

    /* Component name */
    "qtl",

    /* Component Root */
    "",

    /* Application key data */
    __MCC_qtl_session_key,

    /* Component's MATLAB Path */
    MCC_qtl_matlabpath_data,

    /* Number of directories in the MATLAB Path */
    35,

    /* Component's Java class path */
    MCC_qtl_classpath_data,
    /* Number of directories in the Java class path */
    0,

    /* Component's load library path (for extra shared libraries) */
    MCC_qtl_libpath_data,
    /* Number of directories in the load library path */
    0,

    /* MCR instance-specific runtime options */
    MCC_qtl_app_opts_data,
    /* Number of MCR instance-specific runtime options */
    0,

    /* MCR global runtime options */
    MCC_qtl_run_opts_data,
    /* Number of MCR global runtime options */
    0,
    
    /* Component preferences directory */
    "qtl_45D7989BE90B36FF0DE27E47CD8235B7",

    /* MCR warning status data */
    MCC_qtl_warning_state_data,
    /* Number of MCR warning status modifiers */
    0,

    /* Path to component - evaluated at runtime */
    NULL

};

#ifdef __cplusplus
}
#endif


