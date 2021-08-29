var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/AnsweredApplicationQuestions",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "question", render: $.fn.dataTable.render.number(',', '.', 2, '$'), "width": "20%" },
            {
                "data": "questionResponses.questionResponse", "width": "15 % " },
            {
                "data": "id", "render": function (data) {
                    return ` 
                        <div class="text-center">
                            <a href="/ApplicationProfile/Questions/Upsert?id=${data}"
                            class="btn btn-success text-white" style="cursor:pointer; width:50px;">
                            <i class="far fa-edit"></i> 
                            Edit
                            </a>
                        </div>
                     `;
                }, "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}