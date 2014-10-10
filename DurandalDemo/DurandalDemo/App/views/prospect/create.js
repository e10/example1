define(['knockout', 'plugins/router', 'komapping'], function (ko, router, map) {
    var cache = { config: null, enumText: {} };
    var title = 'Prospect';
    var vm = {
        activate: activate,
        types: ko.observableArray([]),
        model: {
            ProspectID: ko.observable(),
            ProspectName: ko.observable(),
            ProspectType: ko.observable(),
            Closed: ko.observable(),
            AdditionalInfo: ko.observable(),
        },
        name: title,
        enums: enums,
        save: saveNow,
        NavBack: NavBack,
    };

    return vm;

    function saveNow(m, e) {
        var validator = $(e.target).closest(".form").kendoValidator().data("kendoValidator");
        if (validator.validate()) {
            $.ajax({
                type: 'post',
                url: '/api/prospect',
                data: map.toJS(vm.model),
                success: function (d) {
                    if (!!d.error) { console.log(d.message); }
                    else {
                        return router.navigateBack();
                    }
                },
            });
        }
    }

    function NavBack() {
        return router.navigateBack();
    }

    function enums() {
        $.ajax({
            type: 'get',
            url: '/api/prospect/prospecttype',
            success: function (d) {
                if (!!d.error) { console.log(d.message); }
                else {
                    console.log(d);
                    vm.types(d);
                }
            },
        });
    }




    //#region Internal Methods
    function activate() {
        return enums();
    }
    //#endregion
});