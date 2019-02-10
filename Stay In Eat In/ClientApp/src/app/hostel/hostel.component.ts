import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-hostel',
  styleUrls: ['./hostel.component.css'],
  templateUrl: './hostel.component.html',
})

export class HostelComponent {

  public Msg: any;
  public hostelDetails: HostelDetails[];
  public hostelArea: Areas[];
  public _http: any;
  public _baseUrl: any;
  public hostelId: any;
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
      "areaOf": "Hostel"
    };
    this.GetAreaList();
  }

  @Injectable()
  public GetAreaList() {
    this._http
      .post(this._baseUrl + 'api/Area/GetAreaList', this.area, this.headers)
      .subscribe(result => {
        this.hostelArea = result;
      });
  }

  @Injectable()
  public GetHostelDetails(){
    this._http
      .post(this._baseUrl + 'api/Hostel/GetHostelDetails', this.hostelId, this.headers)
      .subscribe(data => {
        this.hostelDetails = data;
      });
  }

  @Injectable()
  public SaveHostelDetails() {
    this.Msg = "";
    this._http
      .post(this._baseUrl + 'api/Hostel/SaveHostelDetails', this.hostelDetails, this.headers)
      .subscribe(data => {
        if (data == 1) {
          this.Msg = "Data Successfully Saved";
        }
        else {
          this.Msg = "Some Error Occurred";
        }
      });
  }
}

interface Areas {
  Area: string;
}

interface HostelDetails {
  Name : string;
  Adress : string;
  City : string;
  State : string;
  Pin : string;
  Mobile1 : string;
  Mobile2 : string;
  RoomFor : string;
  Type : string;
  Furnished : string;
  StartingPrice : string;
  FoodAvail : string;
  Area : string;
  Photos : Blob;
}
