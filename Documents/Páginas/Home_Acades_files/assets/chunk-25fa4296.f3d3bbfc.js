(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-25fa4296","chunk-678d4fc4"],{"246e":function(t,e,n){},"8c95":function(t,e,n){"use strict";var i=n("972f"),a=n.n(i);a.a},"972f":function(t,e,n){},"9da7":function(t,e,n){"use strict";n.r(e);var i=function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("BaseEditControls",{attrs:{"block-id":t.$parent.blockId,"block-ref":t.$parent.blockRef,"button-title":t.$t("builder.editImage.title")}},[n("zyro-popup-card",{attrs:{type:"editor",title:t.$t("builder.editImage.popupTitle"),tabs:t.$options.tabs,"current-tab":t.currentTab},on:{change:function(e){t.currentTab=e},close:function(e){return t.$emit("close")}}},[n(t.currentTab.component,{tag:"component"})],1)],1)},a=[],r=n("119c"),o=n("a4df"),l=function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",[n("button",{staticClass:"edit-image__button",style:{backgroundImage:"url("+t.currentElement.settings.image+")"},attrs:{"data-qa":"buildersection-backgroundsettings-btnreplaceimage"},on:{click:function(e){return t.openModal({name:"AssetManager",settings:{type:"element"}})}}},[n("div",{staticClass:"edit-image__button-description"},[n("zyro-svg",{staticClass:"edit-image__icon",attrs:{name:"camera"}}),t._v(" "+t._s(t.$t("common.replaceImage"))+" ")],1)]),n("zyro-field-toggle",{attrs:{id:"object-fit-toggle",checked:"cover"===t.objectFit,label:t.$t("builder.editImage.tabImage.label")},on:{change:function(e){t.objectFit=e}},model:{value:t.objectFit,callback:function(e){t.objectFit=e},expression:"objectFit"}})],1)},s=[],c=n("f3f3"),u=n("2f62"),d=n("7c9b"),b={data:function(){return{id:"",currentElementBeforeEdit:null}},computed:Object(c["a"])({},Object(u["e"])(["currentElementId"]),{},Object(u["c"])(["currentElement"]),{objectFit:{get:function(){return this.currentElement.settings.styles["object-fit"]||"cover"},set:function(t){this.setElementData({data:{settings:{styles:{"object-fit":t.target.checked?"cover":"contain"}}}})}}}),mounted:function(){this.id=this.currentElementId,this.currentElementBeforeEdit=Object(d["a"])(this.currentElement)},beforeDestroy:function(){this.pushElementDataToHistory({elementId:this.id,oldData:this.currentElementBeforeEdit})},methods:Object(c["a"])({},Object(u["d"])(["pushElementDataToHistory","setElementData"]),{},Object(u["d"])("gui",["openModal"]))},m=b,f=(n("8c95"),n("2877")),h=Object(f["a"])(m,l,s,!1,null,"474eb2ce",null),p=h.exports,g=function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",{staticClass:"edit-image-tab-seo"},[n("zyro-field-text",{attrs:{id:t.currentElementId+"alt",bold:!1,label:t.$t("builder.editImage.tabSeo.textFieldLabel")},model:{value:t.alt,callback:function(e){t.alt=e},expression:"alt"}}),n("zyro-label",{staticClass:"edit-image-tab-seo__label"},[t._v(" "+t._s(t.$t("builder.editImage.tabSeo.label"))+" ")])],1)},E=[],v={data:function(){return{altTemp:"",id:""}},computed:Object(c["a"])({},Object(u["e"])(["currentElementRef","currentElementId"]),{},Object(u["c"])(["currentElement"]),{alt:{set:function(t){this.altTemp=t.target.value,this.currentElementRef.$el.querySelector("img").alt=t.target.value},get:function(){return this.currentElement.settings.alt}}}),mounted:function(){this.altTemp=this.currentElement.settings.alt,this.id=this.currentElementId},beforeDestroy:function(){this.setElementData({elementId:this.id,data:{settings:{alt:this.altTemp}},skipHistory:!1})},methods:Object(c["a"])({},Object(u["d"])(["setElementData"]))},k=v,y=(n("e6de"),Object(f["a"])(k,g,E,!1,null,"e5dd3480",null)),I=y.exports,C=function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",[n("zyro-field-toggle",{attrs:{id:"toggle-link-settings",checked:t.addActionActive,label:t.$t("common.addAction")},on:{change:function(e){t.addActionActive=e.target.checked}}}),t.addActionActive?n("LinkSettings",{attrs:{label:t.$t("builder.editButton.tabActionLabel"),"base-target":t.currentElement.settings.target||"_self","base-href":t.currentElement.settings.href,"no-content":""},on:{"settings-update":function(e){t.linkSettingsData=Object.assign({},t.linkSettingsData,e)}}}):t._e()],1)},_=[],w=n("bb9a"),j={components:{LinkSettings:w["a"]},data:function(){return{elementId:null,addActionActive:!1,currentElementBeforeEdit:null,linkSettingsData:{href:"",isUrlValid:!0,target:"",content:""}}},computed:Object(c["a"])({},Object(u["e"])(["currentElementId"]),{},Object(u["c"])(["currentElement"])),watch:{"linkSettingsData.content":function(t){this.setElementData({data:{content:t}})}},beforeMount:function(){this.elementId=this.currentElementId,this.currentElementBeforeEdit=Object(d["a"])(this.currentElement),this.addActionActive=!!this.currentElement.settings.href},beforeDestroy:function(){var t=this.linkSettingsData,e=t.href,n=t.target,i=t.isUrlValid,a={elementId:this.elementId};this.addActionActive?a.data=i?{settings:{href:e,target:n}}:this.currentElementBeforeEdit:a.data={settings:{href:""}},this.setElementData(a),this.pushElementDataToHistory({elementId:this.elementId,oldData:this.currentElementBeforeEdit})},methods:Object(c["a"])({},Object(u["d"])(["pushElementDataToHistory","setElementData"]))},T=j,O=Object(f["a"])(T,C,_,!1,null,null,null),x=O.exports,D=[{title:r["a"].t("common.image"),component:"EditImageTabImage"},{title:r["a"].t("common.seo"),component:"EditImageTabSeo"},{title:r["a"].t("common.action"),component:"EditImageTabAction"}],$={components:{BaseEditControls:o["default"],EditImageTabImage:p,EditImageTabSeo:I,EditImageTabAction:x},data:function(){return{currentTab:this.$options.tabs[0]}},tabs:D},P=$,A=Object(f["a"])(P,i,a,!1,null,null,null);e["default"]=A.exports},a4df:function(t,e,n){"use strict";n.r(e);var i=function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",{staticClass:"edit-actions"},[n("transition",{attrs:{appear:"",name:"popup"}},[t.isEditMode?n("div",{key:"bottom-controls",ref:"editControl",staticClass:"edit-actions__bottom",style:t.editControlPosition},[t._t("default")],2):n("div",{key:"top-controls",ref:"defaultControl",staticClass:"edit-actions__top",style:t.defaultControlPosition},[t.buttonTitle?n("zyro-button",{staticClass:"edit-actions__button",attrs:{theme:"editor","data-qa":"builder-textelementedit-buttonedittext"},on:{click:function(e){return t.executeElementAction("edit")}}},[t._v(" "+t._s(t.buttonTitle)+" ")]):t._e(),t.showDuplicate?n("zyro-button",{staticClass:"edit-actions__button",attrs:{theme:"editor",icon:"duplicate","data-qa":"builder-textelementedit-buttonduplicate",title:t.$t("common.duplicate")},on:{click:function(e){return t.executeElementAction("duplicate")}}}):t._e(),t.showDelete?n("zyro-button",{staticClass:"edit-actions__button",attrs:{theme:"editor",icon:"trash","data-qa":"builder-textelementedit-buttondelete",title:t.$t("common.delete")},on:{click:function(e){return t.executeElementAction("remove")}}}):t._e()],1)])],1)},a=[],r=(n("96cf"),n("c964")),o=n("f3f3"),l=n("2f62"),s=n("4a3e"),c={props:{buttonTitle:{type:String,default:""},blockId:{type:String,required:!0},blockRef:{type:HTMLElement,required:!0},showDuplicate:{type:Boolean,default:!0},showDelete:{type:Boolean,default:!0}},data:function(){return{editControlPosition:{top:0,left:0},defaultControlPosition:{top:0,left:0}}},computed:Object(o["a"])({},Object(l["e"])(["currentElementBoxRef"]),{},Object(l["e"])("gui",["mobilePreviewRef","desktopPreviewRef","isMobileView","isEditMode"]),{},Object(l["c"])(["currentElement"])),watch:{currentElement:function(){this.computeDefaultControlPosition()},isEditMode:function(t){t&&this.computeEditControlPosition()}},mounted:function(){window.addEventListener("keydown",this.onKeyDownPressed),this.isEditMode?this.computeEditControlPosition():this.computeDefaultControlPosition()},beforeDestroy:function(){window.removeEventListener("keydown",this.onKeyDownPressed),window.getSelection?window.getSelection().removeAllRanges():document.selection&&document.selection.empty()},methods:Object(o["a"])({},Object(l["b"])(["duplicateCurrentElement","removeCurrentElement"]),{},Object(l["b"])("gui",["setEditMode"]),{},Object(l["d"])(["setCurrentBlock"]),{},Object(l["d"])("gui",["setRef"]),{onKeyDownPressed:function(t){"Backspace"!==t.key&&"Delete"!==t.key||this.isEditMode||(t.preventDefault(),this.executeElementAction("remove")),(t.ctrlKey||t.metaKey)&&68===t.keyCode&&(t.preventDefault(),this.executeElementAction("duplicate"))},executeElementAction:function(t){switch(this.setCurrentBlock({blockId:this.blockId,blockRef:this.blockRef}),t){case"remove":this.removeCurrentElement();break;case"duplicate":this.duplicateCurrentElement();break;case"edit":this.openEdit();break;default:break}},openEdit:function(){this.setEditMode(!0)},onClose:function(){this.setEditMode(!1)},computeDefaultControlPosition:function(){var t=this;return Object(r["a"])(regeneratorRuntime.mark((function e(){return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,t.$nextTick();case 2:t.defaultControlPosition=s["a"].textEditor(t.currentElementBoxRef,t.isMobileView?t.mobilePreviewRef:t.desktopPreviewRef,t.$refs.defaultControl||t.$refs.editControl);case 3:case"end":return e.stop()}}),e)})))()},computeEditControlPosition:function(){var t=this;return Object(r["a"])(regeneratorRuntime.mark((function e(){return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,t.$nextTick();case 2:"GridTextBox"===t.currentElement.type?t.editControlPosition=s["a"].textEditor(t.currentElementBoxRef,t.isMobileView?t.mobilePreviewRef:t.desktopPreviewRef,t.$refs.editControl):t.editControlPosition=s["a"].editorPopup(t.currentElementBoxRef,t.isMobileView?t.mobilePreviewRef:t.desktopPreviewRef,t.$refs.editControl);case 3:case"end":return e.stop()}}),e)})))()}})},u=c,d=(n("d6a0"),n("2877")),b=Object(d["a"])(u,i,a,!1,null,"19479fe1",null);e["default"]=b.exports},a578:function(t,e,n){},bb9a:function(t,e,n){"use strict";var i=function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",{staticClass:"link-settings"},[t.noContent?t._e():n("zyro-field-text",{attrs:{id:t.elementId+"-text",label:t.label,placeholder:t.$t("common.newLink"),bold:!1,"data-qa":"linksettingsmodal-inputfield-inputname"},model:{value:t.content,callback:function(e){t.content=e},expression:"content"}}),n("zyro-label",[t._v(t._s(t.$t("builder.editButton.linkSettings.label")))]),n("zyro-segment-control",{staticClass:"segment-control",attrs:{controls:t.$options.tabs,"active-control":t.currentTab},on:{change:function(e){t.currentTab=e}}}),"page"!==t.currentTab.tabId?n("zyro-field-text",{attrs:{id:t.elementId+"-link",placeholder:t.$options.placeholders[t.currentTab.tabId],label:t.currentTab.title,error:!t.isDirty||t.isUrlValid?"":t.currentTab.errorMessage,bold:!1,"data-qa":"linksettingsmodal-inputfield-inputurl"},model:{value:t.href,callback:function(e){t.href=e},expression:"href"}}):t._e(),"url"===t.currentTab.tabId?n("zyro-field-toggle",{attrs:{id:t.elementId+"-toggle",checked:"_blank"===t.target,label:t.$t("builder.editButton.linkSettings.toggleFieldLabel")},on:{change:t.toggle}}):t._e(),"page"===t.currentTab.tabId?[n("zyro-label",{staticClass:"dropdown__label"},[t._v(" "+t._s(t.currentTab.title)+" ")]),n("zyro-dropdown",{attrs:{options:t.pages,current:t.currentItem},on:{"update:current":function(e){t.currentItem=e}}})]:t._e()],2)},a=[],r=(n("7db0"),n("4160"),n("fb6a"),n("b0c0"),n("b64b"),n("07ac"),n("ac1f"),n("5319"),n("159b"),n("f3f3")),o=n("119c"),l=n("2f62"),s=n("8dee"),c=n.n(s),u=n("cb53"),d=[{title:o["a"].t("common.page"),tabId:"page"},{title:o["a"].t("common.url"),tabId:"url",validator:u["g"],errorMessage:o["a"].t("validate.url")},{title:o["a"].t("common.phone"),tabId:"phone",validator:u["f"],errorMessage:o["a"].t("validate.phone")},{title:o["a"].t("common.email"),tabId:"email",validator:u["d"],errorMessage:o["a"].t("validate.email")}],b={url:"https://www.example.com",phone:"Ex. 636-48018",email:"example@example.com"},m={tabs:d,placeholders:b,props:{elementId:{type:String,default:c.a.generate()},label:{type:String,default:""},baseTarget:{type:String,default:"_self"},baseHref:{type:String,default:""},baseContent:{type:String,default:""},noContent:{type:Boolean,default:!1}},data:function(){return{isUrlValid:!0,currentTab:null,pages:[],currentItem:null,validator:null,target:"",tempContent:"",isDirty:!1,currentUrl:{url:"",phone:"",email:""}}},computed:Object(r["a"])({},Object(l["e"])(["website"]),{content:{get:function(){return this.tempContent},set:function(t){this.tempContent=t.target.value}},href:{get:function(){return Object(u["k"])(this.currentUrl[this.currentTab.tabId]).replace(/^\/\//,"")},set:function(t){var e=t.target.value,n=this.validator(e);return this.isUrlValid=n.isUrlValid,this.currentUrl[this.currentTab.tabId]=n.url,this.isDirty||(this.isDirty=!0),this.onChange(this.currentUrl[this.currentTab.tabId],this.target,this.isUrlValid),e}}}),watch:{currentTab:function(){var t="page"===this.currentTab.tabId;if(t)this.isUrlValid=!0;else{var e=this.currentTab.tabId;this.validator=this.currentTab.validator;var n=this.validator(this.currentUrl[e]);this.isUrlValid=n.isUrlValid,this.currentUrl[e]=n.url}switch(this.currentTab.tabId){case"page":this.target="_self";break;case"url":this.target=this.baseTarget||"_self";break;default:this.target="_blank"}var i=t?this.currentItem.value:this.currentUrl[this.currentTab.tabId];this.onChange(i,this.target,this.isUrlValid)},currentItem:function(){"page"===this.currentTab.tabId&&this.onChange(this.currentItem.value,this.target,this.isUrlValid)},tempContent:function(){this.$emit("settings-update",{content:this.tempContent})}},beforeMount:function(){var t=this;Object.values(this.website.pages).forEach((function(e,n){var i="";e.name?i=e.name:(i=Object.keys(t.website.pages)[n],i=i.charAt(0).toUpperCase()+i.slice(1)),t.pages.push({title:i,value:e.path})})),this.currentItem=this.findPage(this.baseHref)||this.pages[0];var e=this.getCurrentTabByHref(this.baseHref);this.currentUrl[e.tabId]=this.baseHref,this.currentTab=e,this.tempContent=this.baseContent},methods:{getCurrentTabByHref:function(t){var e=this,n=function(t){return e.$options.tabs.find((function(e){return e.tabId===t}))},i=Object(u["k"])(t);return this.findPage(t)?n("page"):Object(u["f"])(i).isUrlValid?n("phone"):Object(u["d"])(i).isUrlValid?n("email"):n("url")},findPage:function(t){return this.pages.find((function(e){return e.value===t}))},onChange:function(t,e,n){this.$emit("settings-update",{href:t,target:e,isUrlValid:n})},toggle:function(){this.target="_blank"===this.target?"_self":"_blank",this.$emit("settings-update",{target:this.target})}}},f=m,h=(n("f337"),n("2877")),p=Object(h["a"])(f,i,a,!1,null,"6661fdf4",null);e["a"]=p.exports},d6a0:function(t,e,n){"use strict";var i=n("246e"),a=n.n(i);a.a},d7a3:function(t,e,n){},e6de:function(t,e,n){"use strict";var i=n("a578"),a=n.n(i);a.a},f337:function(t,e,n){"use strict";var i=n("d7a3"),a=n.n(i);a.a}}]);