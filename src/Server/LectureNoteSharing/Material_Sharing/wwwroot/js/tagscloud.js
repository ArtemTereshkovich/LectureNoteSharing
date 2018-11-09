$( document ).ready( function() {
    $.ajax({
        url: '/tags/tops',
        method: 'GET',
        dataType: 'json',
        success: tagCloudAdd
    });
    function tagCloudAdd(params){
        var settings = {
            entries: params,
            width: 200,
            height: 200,
            radius: '55%',
            radiusMin:50,
            bgDraw: false,
            opacityOver: 1.00,
            opacityOut: 0.05,
            opacitySpeed: 2,
            fov: 700,
            speed: 0.5,
            fontFamily: 'Oswald, Arial, sans-serif',
            fontSize: '15',
            fontColor: '#444444',
            fontWeight: 'normal',//bold
            fontStyle: 'normal',//italic 
            fontStretch: 'normal',//wider, narrower, ultra-condensed, extra-condensed, condensed, semi-condensed, semi-expanded, expanded, extra-expanded, ultra-expanded
            fontToUpperCase: true
        };
        $( '#tag-cloud' ).svg3DTagCloud( settings );
    };
} );