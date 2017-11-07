$(document).ready(function () {
    var ImageCount = 1;
   
    $('body').on("change", "input[name='files']", function () {

        LastId = $(this).attr('id');
        LastId = String(LastId).substring(4, 5);
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#ImgIn' + LastId).attr('src', e.target.result);
                    $('#ImgIn' + LastId).removeClass("hidden");

                }

                reader.readAsDataURL(input.files[0]);
            }
        }
        if (LastId >= ImageCount)
        {
           
            readURL(this);

            
            var htmlAppend = '<div class="form-group"><div class="col-md-2 control-label">Image ' + ++ImageCount + '</div><div class="col-md-2"> <input class="btn btn-default btn-file" type="file" name="files" id="file' + ImageCount + '"/></div><div class="col-md-2"><a class="btn btn-danger x" href="#">Delete</a></div><div class="col-md-2"><img class="img-responsive hidden" id="ImgIn' + ImageCount + '" src="#" /></div></div>'

            $('#upload-container').append(htmlAppend);
            $('.x').on("click", function () {

                if ($(this).parent().siblings().length > 0) {
                    $(this).parent().parent().remove()
                    if (ImageCount > 1)
                    {
                        ImageCount--;
                    }
                 
                }
            });
        }
        else {
            readURL(this);
        }
     
      

    });

    //$('#file1').change(function () {
    //    readURL(this);
    //});
});