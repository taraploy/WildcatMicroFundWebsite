var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/user/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "fullName", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "applicationUser.role", "width": "15%" },
            {
                "data": {
                    id: "id", roleEdit: "roleEdit"
                },
                "render": function (data) {
                    return ` <div class="text-center">
                                <a class="btn btn-danger text-white" onclick="Upsert('${data.id}')" style="cursor:pointer; width:100px;">
                                    <i class="fas fa-lock-open"></i>
                                Edit
                                </a></div> `;
                },
            }, "width": "25%",
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}

