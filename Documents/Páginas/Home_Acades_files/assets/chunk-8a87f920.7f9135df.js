(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-8a87f920"],{"489b":function(t,a,e){},"92fa":function(t,a,e){"use strict";var n=e("489b"),i=e.n(n);i.a},eb0e:function(t,a,e){"use strict";e.r(a);var n=function(){var t=this,a=t.$createElement,e=t._self._c||a;return e("div",{staticClass:"background",style:t.styles})},i=[],r=e("f3f3"),s=e("2f62"),o={name:"BlockBackground",props:{data:{type:Array,required:!0},id:{type:String,required:!0}},computed:Object(r["a"])({},Object(s["e"])(["website"]),{},Object(s["e"])("navigation",["navigationHeight"]),{},Object(s["c"])(["currentPage","currentBlogPost"]),{styles:function(){if(!this.data||!this.data.length||!this.data[0])return{};var t=this.data[0].image?{backgroundImage:this.data[0].image}:{backgroundColor:this.data[0].color},a=this.isNextToTransparentHeader?{marginTop:"".concat(-this.navigationHeight,"px")}:{};return Object(r["a"])({},t,{},a)},isNextToTransparentHeader:function(){var t=this.website,a=this.currentPage,e=this.currentBlogPost,n=this.id,i=t.blocks.navigation.background[0].isTransparent,r=(null===a||void 0===a?void 0:a.blocks[0])===n||(null===e||void 0===e?void 0:e.blocks[0])===n;return r&&i}})},c=o,u=(e("92fa"),e("2877")),d=Object(u["a"])(c,n,i,!1,null,"857f0f2c",null);a["default"]=d.exports}}]);