// open property editor popup window
function popEditWin(url)
{
  openPopWin(url, 400, 340);
}
function emi(id)
{
//	alert(e.target+' '+e.type);
	document.location.href = '/cms/navmenu/editmenuitem.jsp?id='+id+'&_preview_=1&LangID='+language+'&parentWindowURL='+escape(document.location.href);
	event.cancelBubble = true;
	return false;
}
function dmi(id)
{
	if(confirm('Are you sure to delete this menu item?'))
	{
//		alert('Delete '+id);
		document.location.href = '/cms/wizard/delmenuitem.jsp?id='+id+'&parentWindowURL='+escape(document.location.href);
	}
	event.cancelBubble = true;
	return false;
}
function ami(id, siteID)
{
//	alert('Add '+id);
	document.location.href = '/cms/wizard/addmenuitem.jsp?parentID='+id+'&siteID='+siteID+'&LangID='+language+'&parentWindowURL='+escape(document.location.href);
	event.cancelBubble = true;
	return false;
}
