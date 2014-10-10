define(['knockout', 'plugins/router', 'komapping'], function (ko, router, map) {
    var title = 'Prospect';
    var vm = {
        activate: activate,
        model: ko.observable(),
        trash: trash,
        name: title,
        NavBack: NavBack,
    };

    return vm;

    function trash(m) {
        $.ajax({
            type: 'delete',
            url: '/api/prospect/' + m.ProspectID(),
            success: function (d) {
                if (!!d.error) { console.log(d.message); }
                else {
                    console.log(d);
                    return router.navigate('#');
                }
            },
        });
    }

    function NavBack() {
        return router.navigateBack();
    }

    function getProspect(id) {
        $.ajax({
            type: 'get',
            url: '/api/prospect/' + id,
            success: function (d) {
                if (!!d.error) { console.log(d.message); }
                else {
                    console.log(d);
                    vm.model(map.fromJS(d, {}));
                }
            },
        });
    }

    //#region Internal Methods
    function activate(id) {
        return getProspect(id);

    }
    //#endregion
});