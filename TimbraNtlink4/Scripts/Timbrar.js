$(document).ready(function () {
    $('input[type=file]').change(function () {
        var t = $(this).val();
        var labelText = t.substr(12, t.length);
        //$(this).prev('label').text(labelText);
        $('#xml-name').val(labelText);

    })


});

$("#xml-file").change(function (e) {
    $("#file_error").text('');

    var file = e.target.files[0];
    // fileNameLogo = e.target.files[0].name;
    var reader = new FileReader();
    reader.onload = function (e) {
        $('#hfArchivo').val(e.target.result);
    }
    if (file) {
        reader.readAsDataURL(file);
    }
});

function TimbrarCFDI() {

    var base64 = $("#hfArchivo").val();
    if (base64 == '') {
        $("#file_error").text('seleccione un archivo XML');
        return;
    }
    var request = {
        
        archivo: base64
       }
    var url = $("#RedirectTo").val();

    jQuery.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify(request),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.codigo == "OK") {

                $("#txtSalida").val(data.data);


            } else {
                
                $("#file_error").text(data.data);
            }
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });

}