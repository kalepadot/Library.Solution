@{
  Layout = "_Layout";
}

@Html.ActionLink("View Books", "Index", "Books", null, new { @class = "mdl-button mdl-js-button mdl-button--raised" })
@Html.ActionLink("View Authors", "Index", "Authors",  null, new { @class = "mdl-button mdl-js-button mdl-button--raised" })