var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/questioncategory",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "questionCategory", "width": "40%" },
            {
               
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/Admin/QuestionCategory/upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> Edit
                                </a>
                                <a onClick=Archive('/api/question/'+${data})
                                    class="btn btn-danger text-white style="cursor:pointer; width: 100px;">
                                <i class="far fa-trash-alt"></i>
                                Archive
                                </a>
                    </div>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}


//function Archive(url) {
//    swal({
//        title: "Are you sure you want to archive this question?",
//        text: "",
//        icon: "warning",
//        buttons: true,
//        dangerMode: true
//    }).then((willDisable) => {
//        if (willDisable) {
//            $.ajax({
//                type: 'DISABLE',
//                url: url,
//                success: function (data) {
//                    if (data.success) {
//                        toastr.success(data.message);
//                        dataTable.ajax.reload();
//                    }

//                    else {
//                        toastr.error(data.message);
//                    }
//                }
//            });
//        }
//    });
//}
