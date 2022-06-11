$(document).ready(function () {

	/*close quang cao*/

	$bt = $('#close');
	$nt = $('#note');
	if ($.cookie("close") != null) {
		$nt.remove();
	} else {
		$bt.click(function () {
			$.cookie("close", 1);
			$nt.remove();
		});
	}

	/*click vao dang nhap va nut close*/

	$('#login-hd').click(function () {
		$('.modal-content').fadeIn(500);
		$('.bg-all').css('display', 'block');
		return false;
	});
	$('#close-dn').click(function () {
		$('.modal-content').fadeOut(200);
		$('.bg-all').css('display', 'none');
		return false;

	});

	/*re chuot hien images cart*/

	$('#item-img-cart').hide();
	$aacart = $('#a-cart').html();
	$('#cart').hover(
		function () {
			if ($aacart != "00" && $aacart != "0") {
				$('#item-img-cart').stop().slideDown(300);
			} else {
				$('#item-img-cart').remove();
			}
		},
		function () {
			$('#item-img-cart').stop().slideUp(0);
		}
	);

	/*slide quangcao*/

	myFocus.set({
		id: 'myFocus',
		pattern: 'mF_expo2010',
		txtHeight: 0
	});

	/* Images TOP*/

	$(function () {
		$.fn.scrollToTop = function () {
			$(this).hide().removeAttr("href");
			if ($(window).scrollTop() != "0") {
				$(this).fadeIn("slow")
			}
			var scrollDiv = $(this);
			$(window).scroll(function () {
				if ($(window).scrollTop() == "0") {
					$(scrollDiv).fadeOut("slow")
				} else {
					$(scrollDiv).fadeIn("slow")
				}
			});
			$(this).click(function () {
				$("html, body").animate({
					scrollTop: 0
				}, "slow")
			})
		}
	});
	$(function () {
		$("#toppage1k").scrollToTop();
	});


	/*facebook*/
	(function (d, s, id) {
		var js, fjs = d.getElementsByTagName(s)[0];
		if (d.getElementById(id)) return;
		js = d.createElement(s); js.id = id;
		js.src = "//connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v2.0";
		fjs.parentNode.insertBefore(js, fjs);
	}(document, 'script', 'facebook-jssdk'));

});
function IsEmail(email) {
	var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
	return regex.test(email);
}

$('#fileupload').change(function () {
	var file = $('#fileupload').val();
	var ext = file.split('.').pop().toLowerCase();
	if ($.inArray(ext, ['gif', 'png', 'jpg', 'jpeg']) == -1) {
		alert('file bạn vừa chọn không được phép tải lên.');
		$('#fileupload').val('');
		$('#linkduongdanslide').val('');
		return false;
	}
	$('#linkduongdanslide').val(file);
});