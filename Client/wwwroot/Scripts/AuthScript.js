
function Register() {
    debugger;
    var User = new Object();
    User.Email = $('#Email').val();
    User.Password = $('#Password').val();

    if ($('#Email').val() == "") {
        Swal.fire({
            icon: 'info',
            title: 'Require',
            text: 'Email Cannot be Empty',
        })
        return false;
    } else {
        $.ajax({
            type: 'POST',
            url: '/Auth/Register/',
            data: User
        }).then((result) => {
            debugger;
            if (result.statusCode == 201 || result.statusCode == 200) {
                Swal.fire({
                    icon: 'success',
                    position: 'center',
                    type: 'success',
                    showConfirmButton: false,
                    timer: 1500,
                    title: 'Register Succesfully'
                }).then(function () {
                    //table.ajax.reload();
                    //ClearScreen();
                });
            }
            else {
                Swal.fire('Error', 'Failed to Add User', 'error');
                ShowModal();
            }
        })
    }

}