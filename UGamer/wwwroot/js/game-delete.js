﻿$(document).ready(function ()
{
    $('.js-delete').on('click', function ()
    {
        var btn = $(this);
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-primary mx-2",
                cancelButton: "btn btn-info"
            },
            buttonsStyling: false
        });
        swalWithBootstrapButtons.fire({
            title: "Are you sure you need to delete this game?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
        })
            .then((result) =>
            {
                if (result.isConfirmed) {
                    $.ajax({
                        url: `/Games/Delete/${btn.data('id')}`,
                        method: 'DELETE',
                        success: function ()
                        {
                            swalWithBootstrapButtons.fire
                            ({  
                                title: "Deleted!",
                                text: "Game has been deleted.",
                                icon: "success"
                            });
                            btn.parents('tr').fadeOut();
                        },
                        error: function () {
                            swalWithBootstrapButtons.fire({
                                title: "Ooops...!",
                                text: "Something went wrong.",
                                icon: "error"
                            });
}
                    });
            }
            });
    })
});