var passengerCounter = 0;
var passengerMiles = 0;
var stop = 0;
var busCarbon = 0;
var carCarbon =0;
var distributionCount = [];
var distributionStop = [];
var distributionTime = [];

function getPlotPoints()
{
    var array=[];

    for(var i=0;i<distributionCount.length;i++)
      array.push({x:distributionTime[i]+480,y:distributionCount[i]});

    return array;
}

function getStopPoints()
{
  var array=[0,0,0,0,0,0,0,0];
  var data=[];

  for(var i=0;i<distributionStop.length;i++)
    array[distributionStop[i]]+=distributionCount[i];

  for(var i=0;i<array.length;i++)
    data.push({Label:i,y:array[i]});

  return data;
}

function saveData()
{
  var jsonOb = {counter: passengerCounter, miles: passengerMiles, stop: stop, bus: busCarbon, car: carCarbon, total: passengerTotal, arrayCount: [], arrayTime: [], arrayStop: []};

  for(var i=0;i<distributionStop.length;i++)
  {
      jsonOb.arrayCount.push(distributionCount[i]);
      jsonOb.arrayTime.push(distributionTime[i]);
      jsonOb.arrayStop.push(distributionStop[i]);
  }

  var myJSON = JSON.stringify(jsonOb);
  localStorage.setItem("passengerJSON", myJSON);
}


function setText()
{
  document.getElementById("bus").innerHTML=busCarbon.toFixed(3);
  document.getElementById("car").innerHTML=carCarbon.toFixed(3);
  document.getElementById("total").innerHTML=passengerMiles.toFixed(3);
}

function loadData()
{
  var text = localStorage.getItem("passengerJSON");
  var obj = JSON.parse(text);
  this.passengerCounter=obj.counter;
  this.passengerMiles=obj.miles;
  this.stop=obj.stop;
  this.busCarbon=obj.bus;
  this.carCarbon=obj.car;
  this.passengerTotal=obj.total;

  for(var i=0;i<obj.arrayCount.length;i++)
  {
    this.distributionCount.push(obj.arrayCount[i]);
    this.distributionTime.push(obj.arrayTime[i]);
    this.distributionStop.push(obj.arrayStop[i]);
  }
  setText();
}
