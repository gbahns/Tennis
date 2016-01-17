/// <reference name="MicrosoftAjax.js"/>

Type.registerNamespace("AjaxControlExtender1");

AjaxControlExtender1.ClientBehavior1 = function(element) {
    AjaxControlExtender1.ClientBehavior1.initializeBase(this, [element]);
}

AjaxControlExtender1.ClientBehavior1.prototype = {
    initialize: function() {
        AjaxControlExtender1.ClientBehavior1.callBaseMethod(this, 'initialize');
        
        // Add custom initialization here
    },
    dispose: function() {        
        //Add custom dispose actions here
        AjaxControlExtender1.ClientBehavior1.callBaseMethod(this, 'dispose');
    }
}
AjaxControlExtender1.ClientBehavior1.registerClass('AjaxControlExtender1.ClientBehavior1', Sys.UI.Behavior);

if (typeof(Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();