/*
 ������.
 ������ � ������ �����������? ���� � ������������ ������� ����������.
 */

$(document).ready(function(e) {
	
	/* ���������� ���� 
	
	$('.headerLogo a').remove();
	$('.headerLogo').append('<a class="headerNy" href="/"></a>');
	$('.headerNy')
		.css('background','url(/i/ny_logo.png) 0 0 no-repeat')
		.css('position','absolute')
		.css('margin','-35px 0 0 -42px')
		.css('height','104px')
		.css('width','280px')
	*/	

    /* ������������ ����������� */

    jQuery.preloadImages = function() {
        for (var i = 0; i < arguments.length; i++) {
            jQuery("<img>").attr("src", arguments[i]);

        }
    };

    $.preloadImages(
    	"/i/headerSubmenuBg.png", 
    	"/i/headerSubmenuBorderBottom.png", 
    	"/i/headerSubmenuBorderBottomShadow.png", 
    	"/i/headerSubmenuBorderTop.png", 
    	"/i/headerSubmenuBorderTopShadow.png", 
    	"/i/headerSubmenuContentBg.png"
    );

    /* ����� ������������ ����������� */

    /* ���������� ���� */

    var config = {
        over : showChild,
        timeout : 300,
        out : hideChild,
        interval : 100,
        sensitivity : 1
    }

    function showChild() {
        $('#' + $(this).attr('rel')).show();
    }

    function hideChild() {
        $('#' + $(this).attr('rel')).hide()
    }


    $('.headerMenu div').hoverIntent(config);
    $('.submit').click(function() {
        $('form:first').submit();
    })
    /* ����� ���������� ���� */

    /* ���� ������ ����� */

    $("input[type=file]").filestyle({
        image : "../i/buttonChoose.png",
        imageheight : 21,
        imagewidth : 31,
        width : 250
    });

    /* ����� ���� ������ ����� */

    /* ������������ ��������� � �������� */

    if ($('#pageCurrent').length > 0) {
        $('.pagination').scrollTo('#pageCurrent', {
            over : {
                left : -30
            }
        });
    }

    $('.pagination').jScrollPane();

    /* ����� ������������ ��������� � �������� */
   
    /* ���� � ��������� */

    //$('.contentRightSidebarTabbedPrice .city span.active').append('<ins></ins>');

    /* ����� ���� � ��������� */

});
