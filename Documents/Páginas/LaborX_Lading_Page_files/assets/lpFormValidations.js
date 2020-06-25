var jsonFormFields;
var KeyValueFormFields;
var ConversionURL;
var sendTimeout=null;

confirm_url_target = "";
function updateUI() {}
$(document).ready(function() {
  pwInit();
  pageSize();
  $(window).resize(function() {
    pageSize();
  });
  replacePlaceHolders();
  prePopulateForm();
  storeBrowserData();
  $(".button").css("cursor", "pointer");
  $(".button").click(function(a) {
    if ($(this).children("span.elButton").length > 0) {
      ValidateForm();
    }
  });
  $("a[data-rel*='_popup']").click(function(d) {
    fireLinkClickEvent($(this), d);
    if (clickthroughs_objects[$(this).attr("id")] == null) {
      return;
    }
    var c = clickthroughs_objects[$(this).attr("id")]["deminision"].split(",");
    var b = c[0];
    var a = c[1];
    $.fancybox.open({
      href: $(this).attr("href"),
      width: parseInt(b),
      height: parseInt(a),
      type: "iframe",
      helpers: { overlay: { locked: false } },
      padding: 5
    });
    return false;
  });
  $("a").live("click", function(a) {
    fireLinkClickEvent($(this), a);
  });
  fireClientPixel();
  if (!("placeholder" in document.createElement("input"))) {
    $("input[placeholder], textarea[placeholder]").each(function() {
      var a = $(this).attr("placeholder");
      if (this.value == "") {
        this.value = a;
      }
      $(this)
        .focus(function() {
          if (this.value == a) {
            this.value = "";
          }
        })
        .blur(function() {
          if ($.trim(this.value) == "") {
            this.value = a;
          }
        });
    });
    $("form").submit(function() {
      $(this)
        .find("input[placeholder], textarea[placeholder]")
        .each(function() {
          if (this.value == $(this).attr("placeholder")) {
            this.value = "";
          }
        });
    });
  }
});
function pwInit() {
  try {
    jsonFormFields = getCookie("FormFields");
  } catch (a) {
    return;
  }
  if (jsonFormFields == null) {
    return;
  }
  try {
    jsonFormFields = $.evalJSON(jsonFormFields.replace(/jsonFormFields=/, ""));
  } catch (a) {
    return;
  }
}
function ShowLoadingLayer(a) {
  $("body").prepend(
    '<div id="SaveMask" class="loading-maskPages"><span>' + a + "</span></div>"
  );
  $(".loading-maskPages").height($(document).height());
}
function HideLoadingLayer() {
  if (sendTimeout != null) { clearTimeout(sendTimeout); sendTimeout=null; }
  $("#SaveMask").remove();
}
function fireLinkClickEvent(c, d) {
  if (clickthroughs_objects[$(c).attr("id")] == null) {
    return true;
  }
  var b = clickthroughs_objects[$(c).attr("id")]["save_as_conversion"];
  var f = clickthroughs_objects[$(c).attr("id")]["conversion_code"];
  var a = clickthroughs_objects[$(c).attr("id")]["type"];
  if (a == "telephone" && b == true && f != "") {
    d.preventDefault();
  }
  $.ajax({
    url:
      location.protocol +
      "//" +
      document.domain +
      "/Handler/Clicklog.aspx?PageId=" +
      page_id,
    type: "POST",
    async: false,
    dataType: "json",
    data:
      "mode=clicklog&conversion=" +
      b +
      "&pagedata=" +
      encodeURIComponent(pwpagedata),
    success: function(e) {
      if (e.result == 1) {
        if (a == "telephone" && b == true && f != "") {
          ShowLoadingLayer("Aguarde ...");
          try{
          $("body").append(f);
          setTimeout(function() {
            location.href = $(c).attr("href");
            HideLoadingLayer();
            return true;
          }, 4000);
          } catch {
            location.href = $(c).attr("href");
            HideLoadingLayer();
          }
          return false;
        }
      }
    },
    error: function(e) {
      location.href = $(c).attr("href");
      HideLoadingLayer();
      return true;
    }
  });
}
function fireClientPixel() {
  if (!jsonFormFields) {
    return "";
  }
  if (ConversionURL == null) {
    return "";
  }
  if (ConversionURL == "") {
    return "";
  }
  $("body").append($(ConversionURL));
}
function replacePlaceHolders() {
  if (jsonFormFields == null || jsonFormFields == "") {
    return;
  }
  $(
    "#ElementsArea div.draggable.Htmlembed,#ElementsArea div.draggable.Text,#ElementsArea div.draggable.Headline"
  ).each(function() {
    var b = $(this).html();
    if (b.indexOf("{=") > -1) {
      for (var a = 0; a < jsonFormFields.length; a++) {
        b = b.replace(
          new RegExp("{=" + jsonFormFields[a].key + "}", "g"),
          jsonFormFields[a].value
        );
      }
      $(this).html(b);
    }
  });
  if (location.hostname.indexOf("acades.com.br") > -1) {
    deleteCookie("FormFields");
  }
}
function storeBrowserData() {
  var a = "";
  a += "pid=" + escape(page_id);
  a += "&href=" + escape(window.location.href);
  a += "&hostname=" + escape(window.location.hostname);
  a += "&referrer=" + escape(document.referrer);
  a += "&appCodeName=" + escape(navigator.appCodeName);
  a += "&appName=" + escape(navigator.appName);
  a += "&appVersion=" + escape(navigator.appVersion);
  a += "&cookieEnabled=" + escape(navigator.cookieEnabled);
  a += "&language=" + escape(navigator.appCodeName);
  a += "&platform=" + escape(navigator.platform);
  a += "&userAgent=" + escape(navigator.userAgent);
  a += "&screenWidth=" + escape(window.screen.width);
  a += "&screenHeight=" + escape(window.screen.height);
  setCookie("BrowserData", a);
}
function setCookie(e, c) {
  var d = new Date();
  d.setDate(d.getDate() + 30);
  var h = d.getFullYear();
  var g = d.getMonth();
  var b = d.getDate();
  var a = new Date(h, g, b);
  var f = escape(c) + ";domain=;path=/; expires=" + a.toGMTString();
  document.cookie = e + "=" + f;
}
function getCookie(d) {
  var b,
    a,
    e,
    c = document.cookie.split(";");
  for (b = 0; b < c.length; b++) {
    a = c[b].substr(0, c[b].indexOf("="));
    e = c[b].substr(c[b].indexOf("=") + 1);
    a = a.replace(/^\s+|\s+$/g, "");
    if (a == d) {
      return unescape(e);
    }
  }
}
function deleteCookie(a) {
  document.cookie = a + "=; path=/; expires=Thu, 01 Jan 1970 00:00:01 GMT;";
}
function pageSize() {
  if ($("body").height() < $(window).height()) {
    $("html").css("height", "100%");
  }
}
function showAlert(b, a) {
  switch (alert_type) {
    case "msgbox":
      swal({ title: "", text: a, type: "error", timer: 5000 });
      break;
    case "Tooltip_top":
      $(b).tip({ content: a, onHover: false, position: "top", offset: 10 });
      break;
    case "Tooltip_Bottom":
      $(b).tip({ content: a, onHover: false, position: "bottom", offset: 10 });
      break;
    default:
      $(b).tip({
        content: a,
        onHover: false,
        position: validation_dir,
        offset: 10
      });
      break;
  }
  $(b).focus();
}
function validate_form(f) {
  $("input").hideTip();
  $("select").hideTip();
  $("textarea").hideTip();
  var c;
  var d;
  var a;
  var e = true;
  var b =
    "href=" +
    encodeURIComponent(window.location.href) +
    "&referrer=" +
    encodeURIComponent(document.referrer) +
    "&userAgent=" +
    encodeURIComponent(navigator.userAgent) +
    "&screenWidth=" +
    encodeURIComponent(window.screen.width) +
    "&screenHeight=" +
    encodeURIComponent(window.screen.height);
  var g = f.replace("form_", "");
  $("#pw9bd" + g).val(b);
  $("#" + f + " [data-validation]").each(function(h) {
    c = "";
    c = $(this).attr("data-validation");
    if (c == "") {
      return true;
    }
    d = c.split(",");
    for (var j = 0; j < d.length; j++) {
      switch (d[j]) {
        case "required":
          if (
            $(this).attr("type") == "checkbox" ||
            $(this).attr("type") == "radio"
          ) {
            a = $(this).attr("name");
            if ($('input[name="' + a + '"]:checked').val() == null) {
              showAlert($(this).parent(), required_msg);
              e = false;
              return false;
            } else {
              $(this)
                .parent()
                .hideTip();
            }
          }
          if ($.trim($(this).val()) == "") {
            $(this).focus();
            e = false;
            showAlert($(this), required_msg);
            return false;
          } else {
            $(this).hideTip();
          }
          break;
        case "email":
          if (ValidateEmail($.trim($(this).val())) == false) {
            $(this).focus();
            e = false;
            showAlert($(this), email_msg);
            return false;
          } else {
            $(this).hideTip();
          }
          break;
        case "url":
          if (is_url($.trim($(this).val())) == false) {
            $(this).focus();
            e = false;
            showAlert($(this), "Informe uma url válida.");
            return false;
          } else {
            $(this).hideTip();
          }
          break;
        case "number":
          if (isNumber($.trim($(this).val())) == false) {
            $(this).focus();
            e = false;
            showAlert($(this), numeric_msg);
            return false;
          } else {
            $(this).hideTip();
          }
          break;
        default:
          if (d[j].indexOf("phone") >= 0) {
            if (is_phone(d[j], $.trim($(this).val())) == false) {
              $(this).focus();
              e = false;
              showAlert($(this), phone_msg);
              return false;
            } else {
              $(this).hideTip();
            }
          }
          break;
      }
    }
  });
  if (e == false) {
    return false;
  }
  sendTimeout = setTimeout(HideLoadingLayer, 10000);
  ShowLoadingLayer("Enviando os Dados Para o Servidor ...");
  return true;
}
function ValidateForm() {
  $("input").hideTip();
  $("select").hideTip();
  $("textarea").hideTip();
  var a =
    "href=" +
    encodeURIComponent(window.location.href) +
    "&referrer=" +
    encodeURIComponent(document.referrer) +
    "&userAgent=" +
    encodeURIComponent(navigator.userAgent) +
    "&screenWidth=" +
    encodeURIComponent(window.screen.width) +
    "&screenHeight=" +
    encodeURIComponent(window.screen.height);
  $("#pw9bd").val(a);
  validateStatus = true;
  $('[data-required*="True"]').each(function(b) {
    if ($(this).attr("type") == "checkbox" || $(this).attr("type") == "radio") {
      str_El_name = $(this).attr("name");
      if ($('input[name="' + str_El_name + '"]:checked').val() == null) {
        showAlert($(this).parent(), required_msg);
        validateStatus = false;
        return false;
      } else {
        $(this)
          .parent()
          .hideTip();
      }
    }
    if ($.trim($(this).val()) == "") {
      $(this).focus();
      validateStatus = false;
      showAlert($(this), required_msg);
      return false;
    } else {
      $(this).hideTip();
    }
  });
  if (validateStatus == false) {
    return false;
  }
  $("[data-validation]").each(function(b) {
    ValidationType = $(this).attr("data-validation");
    elmValue = $.trim($(this).val());
    switch (ValidationType) {
      case "None":
        break;
      case "Email":
        if (ValidateEmail(elmValue) == false) {
          $(this).focus();
          validateStatus = false;
          showAlert($(this), email_msg);
          return false;
        } else {
          $(this).hideTip();
        }
        break;
      case "AlphaNumeic":
        if (isAlphaNumeric(elmValue) == false) {
          $(this).focus();
          validateStatus = false;
          showAlert($(this), alphanumeric_msg);
          return false;
        } else {
          $(this).hideTip();
        }
        break;
      case "AlphaBetic":
        if (isAlphabetic(elmValue) == false) {
          $(this).focus();
          validateStatus = false;
          showAlert($(this), alphabetic_msg);
          return false;
        } else {
          $(this).hideTip();
        }
        break;
      case "Numeric":
        if (isNumberonly(elmValue) == true) {
          $(this).focus();
          validateStatus = false;
          showAlert($(this), numeric_msg);
          return false;
        } else {
          $(this).hideTip();
        }
        break;
    }
  });
  if (validateStatus == false) {
    return false;
  }
  
  document.frm.submit();
  $("body").prepend(
    '<div id="SaveMask" class="loading-maskPages"><span>Enviando os Dados ...</span></div>'
  );
}
function ValidateEmail(b) {
  if (b.length == 0) {
    return true;
  }
  var a = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,64})$/;
  if (a.test(b) == false) {
    return false;
  }
  return true;
}
function isAlphabetic(a) {
  if (a.length == 0) {
    return true;
  }
  if (hasNumbers(a) == false) {
    return true;
  }
  return false;
}
function hasNumbers(a) {
  var b = /\d/g;
  return b.test(a);
}
function isAlphaNumeric(a) {
  if (a.match(/^[a-zA-Z0-9]+$/)) {
    return true;
  }
  return false;
}
function isNumber(a) {
  if (a.length == 0) {
    return true;
  }
  return !isNaN(parseFloat(a)) && isFinite(a);
}
function isNumberonly(a) {
  if (a.length == 0) {
    return true;
  }
  return isNaN(a);
}
function is_url(a) {
  var b = /^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$/;
  return b.test(a);
}
function is_phone(g, c) {
  if (c.length == 0) {
    return true;
  }
  var e = c
    .replace(/ /g, "")
    .replace(/\-/g, "")
    .replace(/\./g, "")
    .replace(/\*/g, "")
    .replace(/\+/g, "")
    .replace(/\(/g, "")
    .replace(/\)/g, "")
    .replace(/\#/g, "");
  var b = g.split("_");
  var d = "";
  var a = "";
  if (isNumber(b[1])) {
    d = parseInt(b[1]);
  } else {
    d = 5;
  }
  if (isNumber(b[2])) {
    a = parseInt(b[2]);
  } else {
    a = 20;
  }
  var f = /^[0-9]+$/;
  if (f.test(e) == false || e.length < d || e.length > a) {
    return false;
  }
  return true;
}
function handle_form_confirmation(g, c) {
  var b = JSON.parse($("#" + c + " #submission_action").val());
  var d = Object.keys(b)[0];
  $("#SaveMask").remove();
  switch (d) {
    case "message_box":
      $('input[type="text"], input[type="tel"]').val("");
      $("textarea").val("");
      $("select").prop("selectedIndex", 0);
      swal({ title: "", text: b[d]["message"], type: "success", timer: 3000 });
      break;
    case "redirect_to_url":
      var f = b[d]["url"];
      if (
        parseInt(pwplanid) > 2 &&
        GetQueryVariable(location.href, "pwpass") == "1"
      ) {
        f = ConcatenateFormValuesToURL(f, c);
      }
      if (
        b[d]["target"] == "_self" ||
        b[d]["target"] == null ||
        b[d]["target"] == undefined
      ) {
        location.href = f;
        return;
      }
      var e = b[d]["width"];
      var a = b[d]["height"];
      $('input[type="text"]').val("");
      $("textarea").val("");
      $("select").prop("selectedIndex", 0);
      $.fancybox.open({
        href: f,
        width: parseInt(e),
        height: parseInt(a),
        type: "iframe",
        helpers: { overlay: { locked: false } },
        padding: 5
      });
      break;
    case "redirect_to_file":
      location.href = b[d]["url"];
      break;
  }
}
function ConcatenateFormValuesToURL(b, a) {
  var c = b;
  $(
    "#" +
      a +
      " .field-container:has(input[type='text'],input[type='hidden'],select)"
  ).each(function(e) {
    if ($(this).attr("data-fieldid") != null) {
      var g = $(this)
        .find(".field-label")
        .text()
        .replace("*", "");
      var f = $(this).attr("data-fieldid");
      var d = $("#" + f).val();
      c = ReplaceQueryString(c, g, d);
    }
  });
  return c;
}
function handleComfirmation(d) {
  if (!d) {
    return;
  }
  $('input[type="text"]').val("");
  $("textarea").val("");
  $("select").prop("selectedIndex", 0);
  $("#SaveMask").remove();
  switch (confirm_type) {
    case "alert":
      swal({ title: "", text: confirm_msg, type: "success", timer: 3000 });
      break;
    case "webpage":
      if (confirm_url_target == "_self" || confirm_url_target == "") {
        location.href = confirm_url;
        return;
      }
      var c = confirm_popup_deminision.split(",");
      var b = c[0];
      var a = c[1];
      $.fancybox.open({
        href: confirm_url,
        width: parseInt(b),
        height: parseInt(a),
        helpers: { overlay: { locked: false } },
        type: "iframe",
        padding: 5
      });
      break;
    case "file":
      location.href = confirm_url;
      break;
  }
}
function getValueFromQuerystring(a, c) {
  try {
    return GetQueryVariable(a, $.trim(c));
  } catch (b) {
    return 0;
  }
}
function prePopulateForm() {
  $(".TopHolder label").each(function(a) {
    var b = getValueFromQuerystring(location.href, $(this).text());
    if (b != 0) {
      $(this)
        .parent()
        .find(".el")
        .not('[type="checkbox"]')
        .not('[type="radio"]')
        .val(decodeURIComponent(b));
    }
  });
  $(".field-container").each(function(a) {
    var b = getValueFromQuerystring(
      location.href,
      $(this)
        .find(".field-label")
        .text()
        .replace("*", "")
    );
    if (b != 0) {
      $(this)
        .find(
          "input[type='text'],input[type='hidden'],input[type='tel'],select"
        )
        .val(decodeURIComponent(b));
    }
  });
}
function GetQueryVariable(b, a) {
  if (b.indexOf("?") == 0) {
    b = b.substr(1);
  } else {
    b = b.substring(b.indexOf("?") + 1, b.length);
  }
  var d = b.split("&");
  for (var c = 0; c < d.length; c++) {
    var e = d[c].split("=");
    if (decodeURIComponent(e[0].toLowerCase()) == a.toLowerCase()) {
      return e[1];
    }
  }
  return 0;
}
function ReplaceQueryString(f, g, k) {
  var i = "";
  var b = "";
  var h = "";
  var d = f.indexOf("?" + g + "=");
  var c = f.indexOf("&" + g + "=");
  if (d == -1 && c == -1) {
    i = f;
    if (f.indexOf("?") > -1) {
      b = "&" + g + "=" + k;
    } else {
      b = "?" + g + "=" + k;
    }
  } else {
    var a;
    if (d > -1) {
      a = d + 1;
    } else {
      a = c + 1;
    }
    var j = f.indexOf("=", a);
    i = f.substring(0, j) + "=" + k;
    var e = f.indexOf("&", a);
    b = "";
    if (e > -1) {
      b = f.substring(e);
    }
  }
  h = i + b;
  return h;
}
