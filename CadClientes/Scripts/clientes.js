    var Popup, dataTable;
        $(document).ready(function () {
        dataTable = $("#gridCliente").DataTable({
            "ajax": {
                "url": "/Cliente/ListarClientes",
                "type": "GET",
                "dataType": "json"
            },
            "columns": [
                { "data": "ClienteId" },
                { "data": "Nome" },
                { "data": "Cpf" },
                { "data": "DtNascimento" },
                { "data": "Sexo" },
                {
                    "data": "ClienteId", "render": function (data) {
                        return "<a class='btn btn-secondary btn-sm' style='margin-left:5px' onclick=PopupForm('@Url.Action("IncluirOuEditar")/" + data + "')><i class='fa fa-pencil'></i></a><a class='btn btn-danger btn-sm' style='margin-left:5px' onclick=Delete(" + data + ")><i class='fa fa-trash'></i></a>"
                    },
                    "orderable": false,
                    "searchable": false,
                    "width": "80px"
                },
            ],
            "language": {
                "emptyTable": "Nenhum dado encontrado para exibição"
            }
        });
        });

        function PopupForm(url) {
            var formDiv = $('<div />');
            $.get(url)
                .done(function (response) {
        formDiv.html(response);

                    Popup = formDiv.dialog({
        autoOpen: true,
                        resizable: false,
                        title: 'Preencha as informações do cliente',
                        height: 500,
                        width: 600,
                        close: function () {
        Popup.dialog('destroy').remove();
                        }
                    });
                });
        }

        function SubmitForm(form) {
        $.ajax({
            type: "POST",
            url: form.action,
            data: $(form).serialize(),
            success: function (result) {
                Popup.dialog('close');
                dataTable.ajax.reload();
                $.notify(result.message, "success");
            }
        });
            return false;
        }

        function Delete(id) {
            if (confirm('Deseja excluir o registro ' + id + '?')) {
        $.ajax({
            type: "GET",
            url: '@Url.Action("/Excluir")/' + id,
            success: function (result) {
                dataTable.ajax.reload();
                $.notify(result.message, "success");
            }
        });
            }
        }
