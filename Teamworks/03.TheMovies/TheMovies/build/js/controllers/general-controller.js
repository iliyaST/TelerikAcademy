"use strict";var _slicedToArray=function(){function t(t,e){var a=[],o=!0,r=!1,n=void 0;try{for(var l,i=t[Symbol.iterator]();!(o=(l=i.next()).done)&&(a.push(l.value),!e||a.length!==e);o=!0);}catch(t){r=!0,n=t}finally{try{!o&&i.return&&i.return()}finally{if(r)throw n}}return a}return function(e,a){if(Array.isArray(e))return e;if(Symbol.iterator in Object(e))return t(e,a);throw new TypeError("Invalid attempt to destructure non-iterable instance")}}(),generalControllers={get:function(t,e,a){return{footer:function(){Promise.all([t.getAllCategories(),t.getAllPosts(),t.getLastComment(),a.get("footer")]).then(function(t){var e=_slicedToArray(t,4),a=e[0],o=e[1],r=e[2],n=e[3],l=Handlebars.compile(n),i={},c=void 0;i.categories=a.val(),i.posts=o.val(),i.lastComment=r.val(),c=l(i),$("footer").html(c),window.scrollTo(0,0)}).catch(function(t){return console.log(t)})},home:function(){Promise.all([t.getAllCategories(),t.getAllPosts(),a.get("home")]).then(function(t){var e=_slicedToArray(t,3),a=e[0],o=e[1],r=e[2],n=Handlebars.compile(r),l={},i=void 0;l.categories=a.val(),l.posts=o.val(),i=n(l),$("#container").html(i),$(".main-nav li.active").removeClass("active"),$('a[href^="#/home"]').parent("li").addClass("active"),window.scrollTo(0,0)}).catch(function(t){return console.log(t)})},about:function(){Promise.all([a.get("page-header"),a.get("about")]).then(function(t){var e=_slicedToArray(t,2),a=e[0],o=e[1],r=Handlebars.compile(a),n=Handlebars.compile(o),l={title:"About Us",subtitle:"About Us Subtitle",breadcrumbs:[{url:"#/home",title:"Home"},{url:"#/about",title:"About"}]},i=r(l),c=n();$("#container").html(c),$(".page-header").html(i),$(".main-nav li.active").removeClass("active"),$('a[href^="#/about"]').parent("li").addClass("active"),window.scrollTo(0,0)}).catch(function(t){return console.log(t)})},contact:function(){Promise.all([a.get("page-header"),a.get("contact")]).then(function(t){var a=_slicedToArray(t,2),o=a[0],r=a[1],n=Handlebars.compile(o),l=Handlebars.compile(r),i={title:"Contact Us",subtitle:"Contact Us Subtitle",breadcrumbs:[{url:"#/home",title:"Home"},{url:"#/contact",title:"Contact Us"}]},c=n(i),s=l();$("#container").html(s),$(".page-header").html(c),$(".main-nav li.active").removeClass("active"),$('a[href^="#/contact"]').parent("li").addClass("active"),window.scrollTo(0,0),$(".btn-add-comment").click(function(t){var a=$("#message").val(),o={authorKey:JSON.parse(localStorage.getItem("currentUser")).uid,authorName:JSON.parse(localStorage.getItem("currentUser")).displayName,authorEmail:JSON.parse(localStorage.getItem("currentUser")).email,authorImg:JSON.parse(localStorage.getItem("currentUser")).photoURL,content:a};e.sendMessage(o).then(function(t){toastr.info("Thank you for contacting us!")}).catch(function(t){toastr.error("Message was not sent successfully!")})})})}}}};