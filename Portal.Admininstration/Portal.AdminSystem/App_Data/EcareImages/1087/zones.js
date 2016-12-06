switch (sCurrentPage.toLowerCase()) {
    case "life":
        buildSldrKit(ContEntID, sCurrentPage, clientID, useThisURL);
        break;
    case "wellbeing":
        buildSldrKit(ContEntID, sCurrentPage, clientID, useThisURL);
        break;
    default:
        //buildSldrKit('@ViewData["ContentEntityID"]', '@ViewBag.CurrentPage', '@ViewData["clientID"]', '@ViewData["useThisURL"]');
        buildSldrKit(ContEntID, sCurrentPage, clientID, useThisURL);
        break;
}
