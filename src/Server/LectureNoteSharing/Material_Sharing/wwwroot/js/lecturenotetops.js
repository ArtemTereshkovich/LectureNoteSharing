
$(document).ready( function(){
        request(page);        
    });

function request(page){
    $.ajax({
        url : "/lecturenote/tops?page=" + page,
        type : "get",
        success : addPosts
    });
};

function addPosts(params){
    
    if(lockScroll != true){
        page++;
        $.each(params, function (index) {
            var param = params[index];                
            addPost(param);
        });
        if(params.length <5)
            lockScroll = true;    
        $(window).on('scroll', onScroll);
    }
    
};

function addPost(param){
    var post = document.createElement('div');
    post.className += 'card mb-4';

    var postBody = document.createElement('div');
    postBody.className += 'card-body';

    var title = document.createElement('h2');
    title.className += 'card-title';
    title.innerText = param.title;

    var description = document.createElement('p');
    description.className += 'card-text';
    description.innerText = param.description;

    var specialty = document.createElement('p');
    specialty.className += 'lead';
    specialty.innerText += 'Specialty: ' + param.specialtyNumber;

    var readmorebtn = document.createElement('a');
    readmorebtn.href = '/lecturenote/view?id=' + param.id;
    readmorebtn.innerText ="Read"
    readmorebtn.className += 'btn btn-secondary';

    postBody.appendChild(title);
    postBody.appendChild(description);
    postBody.appendChild(specialty);
    postBody.appendChild(readmorebtn);

    var postInf = document.createElement('div');
    postInf.className += 'card-footer text-muted';
    postInf.innerText = 'Posted on ' + param.dateOfEdit + ' ';
    

    var username = document.createElement('a');
    username.innerText = param.authorUsername;
    username.href = '/lecturenote/user?username=' + param.authorUsername;

    var ratingBody = document.createElement('div');
    ratingBody.className += 'star-rating';
    ratingBody.style = 'float : right;'

    var ratingWidget = document.createElement('div');
    ratingWidget.className += 'rating-widget';

    var stars = document.createElement('div');
    stars.className += 'rating-stars';

    var ulstars = document.createElement('ul');
    ulstars.id = 'stars';
    ulstars.setAttribute('post-id',param.id);
    ulstars.setAttribute('rating-average',param.averageRating);
    
    loadRating(ulstars);

    var avrating = document.createElement('p');
    avrating.innerText = 'Average Rating:' + ' ' +param.averageRating;
    
    stars.appendChild(ulstars);

    ratingWidget.appendChild(stars);

    ratingBody.appendChild(ratingWidget);

    postInf.appendChild(username);
    postInf.appendChild(ratingBody);
    postInf.appendChild(avrating);
    
    post.appendChild(postBody);
    post.appendChild(postInf);

    document.getElementById('posts').appendChild(post);
   
};

function loadRating(element){ 
   
    var Id = $(element).attr('post-id');
    var datareq = { postId : Id };
    $.ajax({
        url : "rating/get",
        data : datareq,
        type : "GET",
        success : function(data){            
            insertRating(data,element);
        }
    });
}

function putRating(){    
    var Rating = parseInt($(this).data('value'), 10);    
    var prevRating = parseInt($(this).parent().attr('rating-value'),10);    
    if(Rating != prevRating){

        var postId = $(this).parent().attr('post-id');
        $(this).parent().attr('rating-value',Rating);
        var ratingData = {postId : postId, rating : Rating};       

        $.ajax({
            headers: {
                'Content-Type': 'application/json'
            },
            url : "/rating/put",
            type : "POST",
            data: JSON.stringify(ratingData),
            dataType: 'application/json',
            error : function (response, text) { 
                if(response.status == 401){
                    location.replace("/account/login");
                }
             }         
        });
        
        var stars = $(this).parent().children('li.star');
        for (i = 0; i < stars.length; i++) {
                $(stars[i]).removeClass('selected');
            }

        for (i = 0; i < Rating; i++) {
            $(stars[i]).addClass('selected');
            }        
    }
}

function hoverStar(){
    var onStar = parseInt($(this).data('value'), 10); // The star currently mouse on
   
    // Now highlight all the stars that's not after the current hovered star
    $(this).parent().children('li.star').each(function(e){
    if (e < onStar) {
        $(this).addClass('hover');
    }
    else {
        $(this).removeClass('hover');
    }});
};

function unhoverStar(){
    $(this).parent().children('li.star').each(function(e){
            $(this).removeClass('hover');
        });
};

function insertRating(data,element){
    if(data.liked)
        $(element).attr('rating-value',data.rating);
    else
        $(element).attr('rating-value',0);

    var i;    
    for (i = 1; i < 6; i++) {
        var starli = document.createElement('li');
        $(starli).addClass('star');
        $(starli).attr('data-value',i);
        var stari = document.createElement('i');
        $(stari).addClass('fa fa-star fa-fw');
        if(i <= data.rating){
            $(starli).addClass('selected');
        }
        $(starli).append(stari);
        $(starli).on('mouseover',hoverStar)
            .on('mouseout',unhoverStar)
            .on('click',putRating);
        element.append(starli);
    };    
}