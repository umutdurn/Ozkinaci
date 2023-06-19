//$(document).ready(function () {
//    $('input#product_seo_desc').characterCounter();
//    //$('select').material_select();
//    $('select').formSelect();
//    $("#product_name").change("input", function () {
//        const yeni = $(this).val().toLowerCase().replace(/ç/, "c")
//            .replace(/ş/g, "s")
//            .replace(/'/g, "")
//            .replace(/ı/g, "i")
//            .replace(/ş/g, "s")
//            .replace(/g/g, "g")
//            .replace(/ç/g, "c")
//            .replace(/ü/g, "u")
//            .replace(/ /g, "-");
//        $("#pruduct_url").val(yeni);
//    });

//    $("#signupForm").validate({
//        rules: {
//            Name: {
//                required: true,
//                minlength: 3
//            },
//            SeoUrl: {
//                required: true
//            },
//            Stock: {
//                required: true,
//            },
//            SeoDescription: {
//                required: true,
//                minlength: 10
//            },
//            SubCategory: {
//                required: true
//            },
//            Description: {
//                required: true,
//                minlength: 20
//            },

//        },
//        messages: {
//            Name: {
//                required: "Lütfen ürün ismi giriniz",
//                minlength: "Ürün adınız en az 2 karakter olmalıdır"
//            },
//            SeoUrl: {
//                required: "Lütfen Seo Url giriniz",

//            },
//            Stock: {
//                required: "Lütfen ürün stoğu giriniz",
                
//            },
//            SeoDescription: {
//                required: "Ürün Seo açıklaması giriniz.",
//                minlength: "Ürün açıklamanız en az 10 karakter olmalıdır"
//            },
//            SubCategory: {
//                required: "Lütfen kategori seçiniz"
                
//            },
//            Description: {
//                required: "Ürün açıklaması giriniz.",
//                minlength: "Ürün açıklamanız en az 20 karakter olmalıdır"
//            },
            
//        }
//    });
//    $.validator.setDefaults({
//        ignore: []
//    });
    

//    $(function () {
//        $('#product_price').maskMoney();
//    })

//    BringBackImages();

//});

//function BringBackImages() {


//    var id = window.location.href.split("/").pop();

//    $.ajax({
//        url: '/Admin/BringBackImages/' + id,
//        type: "POST",
//        success: function (result) {
//            if (result != "") {

//                UploadGetir(result);

//            }
//        }
//    });

//}



//ClassicEditor
//    .create(document.querySelector('#Description'), {
//        // toolbar: [ 'heading', '|', 'bold', 'italic', 'link' ]
//    });
