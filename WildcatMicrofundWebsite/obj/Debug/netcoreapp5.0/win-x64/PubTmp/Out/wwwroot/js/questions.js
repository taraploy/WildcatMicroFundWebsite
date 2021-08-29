var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "order": [[2, "asc"]],
        "ajax": {
            "url": "/api/question",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "question", "width": "50%" },
            { "data": "questionCategories.questionCategory", "width": "10%" },
            { "data": "questionOrder", "width": "10%" },
            { "data": "questionType", "width": "10%" },

            {
                "data": "id",
                "render": function (data) {
                    return ` 
                        <div class="text-center">
                            <a href="/Admin/Questions/Upsert?id=${data}"
                            class="btn btn-success text-white" style="cursor:pointer; width:80px;">
                            <i class="far fa-edit"></i> 
                            Edit
                            </a>
                            <a onClick=Archive('/api/question/'+${data})
                            class="btn btn-danger text-white style="cursor:pointer; width: 80px;">
                            <i class="far fa-trash-alt"></i>
                            Archive
                            </a>
                        </div>`;
                }, "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}