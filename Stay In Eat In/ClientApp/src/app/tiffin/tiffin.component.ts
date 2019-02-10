import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-tiffin',
  styleUrls: ['./tiffin.component.css'],
  templateUrl: './tiffin.component.html',
})
export class TiffinComponent {

  public Msg: any;
  public tiffinDetails: any;
  public tiffinArea: Areas[];
  public _http: any;
  public _baseUrl: any;
  public area: any;
  public headers = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  

  public constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
    this.area = {
      "areaOf": "Tiffin"
    };
    this.tiffinDetails = {
      "Name" : "",
      "Area": "",
      "Mobile1": "",
      "Mobile2": "",
      "NonVeg": "",
      "Type": "",
      "ServingTime": "",
      "StartingPriceVeg": "",
      "StartingPriceNVeg": ""
    };
    this.GetAreaList();
  }

  @Injectable()
  public SaveTiffinDetails() {
    this.Msg = "";
    this._http
      .post(this._baseUrl + 'api/Tiffin/SaveTiffinDetails', this.tiffinDetails, this.headers)
      .subscribe(data => {
        if (data == 1) {
          this.Msg = "Data Successfully Saved";
        }
        else {
          this.Msg = "Some Error Occurred";
        }
      });
  }

  @Injectable()
  public GetAreaList() {
    this._http
      .post(this._baseUrl + 'api/Area/GetAreaList', this.area, this.headers)
      .subscribe(result => {
        this.tiffinArea = result;
      });
  }
}

interface Areas {
  Area: string;
}
