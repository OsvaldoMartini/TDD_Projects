# TDD_Projects

TDD - Parsing JSON

Following the Cycles
Red 	 ->  Failing Unit Test
Green 	 -> Just Enough Code to Pass Test
Refactor -> (Yellow) Clean Up Code
	
Good Path -> (good data)
JSON Data:
{  
   "result":{  
      "sunrise":"6:37:49 AM",
      "sunset":"4:42:49 PM",
      "solar_noon":"11:40:19 AM",
      "day_length":"10:05:00.1530000"
   },
   "status":"OK"
}

Sad Path -> (bad data)
JSON Data:
{  
   "results":null,
   "status":"ERROR"
}
	
Check GetServiceQtdMovies()
HardCode file: HackerRank_1.json
HardCode file: HackerRank_2.json
https://jsonmock.hackerrank.com/api/movies/search/
https://jsonmock.hackerrank.com/api/movies/search/?Title=Waterworld
	

	
Aux Tool will create Scapes in Json File
https://www.freeformatter.com/java-dotnet-escape.html#ad-output
