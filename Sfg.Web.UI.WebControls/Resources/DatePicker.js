/*DatePicker.prototype.show = function (dt, x, y, callback, relpath) {
	if (dt) {
		this.dt = dt;
	}
	this.callback = callback;
	// if not rendered yet, do so
	if (!this.oSpan) {
		this.render (relpath);
	}
	// set coordinates
	this.oSpan.style.position = "absolute";
	if (x < 179) {
		x = 179;
	}
	if (y < 25) {
		y = 25;
	} else {
		y = y + 25;
	}
	this.oSpan.style.left = x - 179;
	this.oSpan.style.top = y;
	this.fill();

	this.oIFrame.style.width = this.oTable1.clientWidth;
	this.oIFrame.style.height = this.oSpan.style.height;
	this.oIFrame.style.position = "absolute";
	this.oIFrame.style.left = 0;
	this.oIFrame.style.top = 0;
	this.oIFrame.style.visibility = "visible";
	
	this.oSpan.style.visibility = "visible";
	this.oMonth.focus();
}

DatePicker.prototype.fill = function() 
{
	// first clear all
	this.clear();
	
	// place the dates in the calendar
	var nRow = 0;
	var d = new Date (this.dt.getTime());
	var m = d.getMonth();
	for (d.setDate (1); d.getMonth() == m; d.setTime (d.getTime() + 86400000)) 
	{
		var nCol = d.getDay();
		if (nCol == 0) 
		{
			nCol = 7;
		}
		nCol = nCol - 1;
		this.aCells[nRow][nCol].innerHTML = d.getDate();
		if (d.getDate() == this.dt.getDate()) 
		{
			this.aCells[nRow][nCol].className = 'DatePickerBtnSelect';
			this.aCells[nRow][nCol].bgColor = "orange";
		}
		if (nCol == 6) 
		{
			nRow++;
		}
	}
	
	// set the month combo
	this.oMonth.value = m;
	
	// set the year text
	this.oYear.value = this.dt.getFullYear();
}

DatePicker.prototype.onPrev = function() 
{
	this.dt = getPrevMonth(this.dt);
	this.fill();
}

DatePicker.prototype.onNext = function() 
{
	this.dt = getNextMonth(this.dt);
	this.fill();
}

DatePicker.prototype.onMonth = function() 
{
	this.dt.setMonth (this.oMonth.value);
	this.fill();
}

DatePicker.prototype.onYear = function() 
{
	this.dt.setYear (this.oYear.value);
	this.fill();
}

DatePicker.prototype.onDay = function (oCell) 
{
	var d = parseInt (oCell.innerHTML);
	
	if (d > 0) 
	{
		this.dt.setDate (d);
		this.hide();
		this.callback (this.dt);
	}
}

DatePicker.prototype.onToday = function() 
{
	this.dt = new Date();
	this.fill();
}

DatePicker.prototype.onYesterday = function() 
{
	this.dt = getPrevDay();
	this.fill();
}

DatePicker.prototype.onTomorrow = function() 
{
	this.dt = getNextDay();
	this.fill();
}

DatePicker.prototype.onWeekAgo = function() 
{
	this.dt = getPrevWeek();
	this.fill();
}

DatePicker.prototype.onWeekAfter = function() 
{
	this.dt = getNextWeek();
	this.fill();
}

DatePicker.prototype.onMonthAgo = function() 
{
	this.dt = getPrevMonth(new Date(2006,3-1,31));
	this.fill();
}


DatePicker.prototype.onMonthAfter = function() 
{
	this.dt = getNextMonth();
	this.fill();
}

DatePicker.prototype.texts = {
	months: [ "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" ],
	close: "Close",
	days: ["Su", "M", "Tu", "W", "Th", "F", "Sa"],
	monthTitle: "Month",
	prevMonth: "Prev Month",
	nextMonth: "Next Month",
	yearTitle: "Year",
	today: "Today",
	yesterday: "Yesterday",
	tomorrow: "Tomorrow",
	weekAgo: "Last Week",
	weekAfter: "Next Week",
	monthAgo: "Prev Month",
	monthAfter: "Next Month"
}

*/

/********************/
/*** Date Helpers ***/
/********************/
var minute = 1000 * 60;
var hour = minute * 60;
var day = hour * 24;
var week = day * 7;

function isLeapYear(year)
{
	return ((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0);
}
            
var daysInMonth = [31,28,31,30,31,30,31,31,30,31,30,31];
function getDaysInMonth(d) 
{
	var month = d.getMonth();
	if ((month == 1) && isLeapYear(d.getFullYear())) 
		return 29;
	return daysInMonth[month];
}

function getOtherDate(d)
{
	if (!d) d = new Date();
	return d;
}

function DateAdd(d,timeSpan)
{
	if (!d) d = new Date();
	return new Date(d.getTime()+timeSpan);
}

function getPrevDay(d)
{
	return DateAdd(d,-day);
}

function getNextDay(d)
{
	return DateAdd(d,day);
}

function getPrevWeek(d)
{
	return DateAdd(d,-week);
}

function getNextWeek(d)
{
	return DateAdd(d,week);
}

function MonthAdd(d,months)
{
	var targetDayOfMonth = d.getDate();
	d.setDate(1);
	d.setMonth(d.getMonth()+months);
	var daysInMonth = getDaysInMonth(d);
	d.setDate(targetDayOfMonth > daysInMonth ? daysInMonth : targetDayOfMonth);
	return d;
}

function getPrevMonth(d)
{
	if (!d) d = new Date();
	var targetDayOfMonth = d.getDate();
	d.setDate(1);
	if (d.getMonth() == 0) 
	{
		d.setYear (d.getFullYear() - 1);
		d.setMonth (11);
	} 
	else 
	{
		d.setMonth(d.getMonth() - 1);
	}
	var daysInMonth = getDaysInMonth(d);
	d.setDate(targetDayOfMonth > daysInMonth ? daysInMonth : targetDayOfMonth);
	return d;
}

function getNextMonth(d)
{
	if (!d) d = new Date();
	var targetDayOfMonth = d.getDate();
	d.setDate(1);
	if (d.getMonth() == 11) 
	{
		d.setYear (d.getYear() + 1);
		d.setMonth (0);
	} 
	else 
	{
		d.setMonth (d.getMonth() + 1);
	}
	var daysInMonth = getDaysInMonth(d);
	d.setDate(targetDayOfMonth > daysInMonth ? daysInMonth : targetDayOfMonth);
	return d;
}

function TestDateMath()
{
	var dates = [
		new Date(2006,1-1,1),
		new Date(2006,1-1,8),
		new Date(2006,1-1,31),
		new Date(2006,3-1,1),
		new Date(2006,3-1,8),
		new Date(2006,3-1,31),
		new Date(2006,12-1,1),
		new Date(2006,12-1,8),
		new Date(2006,12-1,31)
		];
	var s = "";
	for (var i=0; i<dates.length; i++)
	{
		s += dates[i].toDateString() + " => " + getNextMonth(dates[i]).toDateString() + "\n";
	}
	alert(s);
}

/********************/

function getElementPosition (elem) {
	var offsetTrail = elem;
	var offsetLeft = 0;
	var offsetTop = 0;
	
	while (offsetTrail) {
		offsetLeft += offsetTrail.offsetLeft;
		offsetTop += offsetTrail.offsetTop;
		offsetTrail = offsetTrail.offsetParent;
	}
	if ((navigator.userAgent.indexOf ("Mac") != -1) && (typeof document.body.leftMargin != "undefined")) {
		offsetLeft += document.body.leftMargin;
		offsetTop += document.body.topMargin;
	}

	return {left:offsetLeft, top:offsetTop, right:offsetLeft+elem.clientWidth, bottom:offsetTop+elem.clientHeight};
}

// Check if the user entered a valid date
// if not, set foreground color to red
// Att. this function checks the german date format DD.MM.YYYY (short format too)
function CheckDatePickerDate (ObjectID) {
	var value = document.getElementById (ObjectID).value;
	var rcode = true;
	var bYearSet = false, bMonthSet = false, bDaySet = false;
	var Day = "", Month = "", Year = "";

	for (i = 0; i < value.length; i++) {
		if (value.charAt (i) != ".") {
			if (bMonthSet) {
				if (Year.length < 4) {
					Year += value.charAt (i);
					bYearSet = true;
				} else {
					rcode = false;
				}
			} else {
				if (bDaySet) {
					Month += value.charAt (i);
				} else {
					Day += value.charAt (i);
				}
			}
		} else {
			if (bYearSet) {
				rcode = false;
			}
			if (bDaySet == false) {
				bDaySet = true;
			} else {
				if (bMonthSet == false) {
					bMonthSet = true;
				}
			}
		}
	}

	if (Year.length == 0) {
		rcode = false;
	}

	Month -= 1;
	var Datum = new Date (Year, Month, Day);

	if (Datum.getYear() == Year && Datum.getMonth() == Month && Datum.getDate() == Day) {
	} else {
		rcode = false;
	}

	if (rcode) {
		document.getElementById (ObjectID).style.color = document.fgColor;
	} else {
		document.getElementById (ObjectID).style.color = "#ff0000";
	}
	
	return rcode;
}


function toggleElement(element)
{
	showElement(element,!isElementVisible(element));
}

function showElement(element,visible)
{
	if (typeof(element)=='string')
		element = document.getElementById(element); 
	if (typeof(visible)=='undefined') 
		visible = true;
	element.style.display = visible ? 'block' : 'none';
}

function hideElement(element)
{
	showElement(element,false);
}

function isElementVisible(element)
{
	if (typeof(element)=='string')
		element = document.getElementById(element); 
	return element.style.display != 'none';
}


////////////////////////////////////////////
// Calendar class constructor and methods //
////////////////////////////////////////////

//constructor for the Calendar object; must be called with the new operator
function Calendar(id,style,autoCloseMode,date)
{
	calendars[id] = this;
	
	this.div = document.getElementById(id);
	if (!this.div)
		return;
	this.iframe = document.getElementById(id+'_iframe');
	this.cmbMonth = document.getElementById(id+'$calendarMonth');
	this.cmbYear = document.getElementById(id+'$calendarYear');
	this.txtDate = document.getElementById(id+'_textBox');
	this.image = document.getElementById(id+'_image');
	
	//disable selecting so double-clicking doesn't select the text
	this.div.onselectstart = function() {return false;} // ie
	this.div.onmousedown = function() {return false;} // mozilla
	this.div.onclick = function() {return true;} // mozilla re-enable
	
	this.style = style;
	this.div.allowHide = style=='Dynamic';
	
	this.autoCloseMode = autoCloseMode;

	if (date)
		this.date = date;
	else
		this.dateFromString(this.txtDate.value);

	this.fill();
}

function Calendar.prototype.hide() 
{
	if (!this.div.allowHide) 
		return;
	hideElement(this.div);
}

function Calendar.prototype.show() 
{
	if (!this.div.allowHide)
		return;
	
	showElement(this.div);
	var pos = getElementPosition(this.image);
	if (pos.bottom + this.div.clientHeight > document.body.clientHeight)
		this.div.style.top = pos.top - this.div.clientHeight;
	else
		this.div.style.top = pos.bottom;
	this.div.style.left = pos.right - this.div.clientWidth + 2;
	
	this.iframe.style.width = this.div.clientWidth;
	this.iframe.style.height = this.div.clientHeight;
	this.iframe.style.zIndex = -1;
	
	this.cmbMonth.focus();
	
	this.fill();
}

//calendar.toggle = function() {toggleElement(this.div);}
function Calendar.prototype.checkfocus() 
{
	if (isElementVisible(this.div)) this.div.focus();
}

function Calendar.prototype.onTextChanged()
{
	this.dateFromString(this.txtDate.value);
	this.fill();
}

function Calendar.prototype.onDayClick(elem)
{
	if (this.autoCloseMode=="SingleClick" && (this.date ? this.date : new Date()).getMonth() == elem.date.getMonth())
		this.hide();
	this.date = elem.date;
	this.fill();
	return true;
}

function Calendar.prototype.onDayDoubleClick()
{
	if (this.autoCloseMode=="DoubleClick")
		this.hide();
	return true;
}

function Calendar.prototype.onMonthChanged()
{
	this.date = MonthAdd(this.date, this.cmbMonth.value - this.date.getMonth());
	this.fill();
}

function Calendar.prototype.onYearChanged()
{
	this.date = MonthAdd(this.date, 12 * (this.cmbYear.value - this.date.getFullYear()));
	this.fill();
}

function Calendar.prototype.prevMonth()
{
	this.date = MonthAdd(this.date, -1);
	this.fill();
}

function Calendar.prototype.nextMonth()
{
	this.date = MonthAdd(this.date, 1);
	this.fill();
}

function Calendar.prototype.checkhide() 
{
	if (!this.div.contains(document.activeElement))
		this.hide();
}

function Calendar.prototype.setText()
{
	this.txtDate.value = calendar.div.contains(document.activeElement) + ':' + document.activeElement.id;
}

//this function can be customized to support other cultures
function Calendar.prototype.dateToString()
{
	return this.date ? (this.date.getMonth()+1)+'/'+this.date.getDate()+'/'+this.date.getFullYear() : "";
}

//this function can be customized to support other cultures
function Calendar.prototype.dateFromString(s)
{
	var dateval = Date.parse(s);
	this.date = dateval ? new Date(dateval) : null;
}

function Calendar.prototype.fill()
{
	var d = new Date (this.date ? this.date : new Date());
	var m = d.getMonth();
	
	d.setDate(1); //start at first of month
	d = DateAdd(d,-d.getDay()*day); //then wind back to nearest sunday
	
	for (var j = 0; j < 6; j++) 
	{
		for (var i = 0; i < 7; i++, d=DateAdd(d,day)) 
		{
			var a = document.getElementById(this.div.id+'$'+j+'$'+i);
			var td = a.parentElement;
			a.innerHTML = d.getDate();
			//td.innerHTML = '<a onclick="" >'+d.getDate()+'</a>';

			if (this.date && d.toDateString() == this.date.toDateString())
				td.className = "Selected";
			else if (d.getMonth() != m)
				td.className = "OtherMonth";
			else if (d.toDateString() == new Date().toDateString())
				td.className = "Today";
			else
				td.className = "";
				
			a.date = d;
		}
	}
	
	this.cmbMonth.value = m;
	this.cmbYear.value = this.date ? this.date.getFullYear() : new Date().getFullYear() ;
	this.txtDate.value = this.dateToString();
}

var calendars = [];
