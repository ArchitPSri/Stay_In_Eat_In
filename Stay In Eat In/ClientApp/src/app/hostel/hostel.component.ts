import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-hostel',
  styleUrls: ['./hostel.component.css'],
  templateUrl: './hostel.component.html',
})
export class HostelComponent {

  public Msg: any;
  public hostelDetails: any;
  public hostelArea: any;
  public _http: any;
  public _baseUrl: any;
  public areaOf: string;
  public headers = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  

  public constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
    this.areaOf = 'Hostel';
    this.hostelDetails = {
      "Name" : "",
      "Area": "",
      "Adress": "",
      "City": "",
      "State": "",
      "Pin": "",
      "Mobile1": "",
      "Mobile2": "",
      "RoomFor": "",
      "Type": "",
      "Furnished": "",
      "StartingPrice": "",
      "FoodAvail": ""
    };
    this.hostelArea = {
      "Name" : "",
    };
    //this.GetAreaList();
    this._http
      .post(this._baseUrl + 'api/SIEI_AreaController/GetAreaList', this.areaOf, this.headers)
      .subscribe(result => {
        this.hostelArea = result;
      });
      this._http
      .post(this._baseUrl + 'api/HostelController/SaveHostelDetails', this.hostelDetails, this.headers)
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
  public SaveHostelDetails() {
    this.Msg = "";
    this._http
      .post(this._baseUrl + 'api/HostelController/SaveHostelDetails', this.hostelDetails, this.headers)
      .subscribe(data => {
        if (data == 1) {
          this.Msg = "Data Successfully Saved";
        }
        else {
          this.Msg = "Some Error Occurred";
        }
      });
  }

  // @Injectable()
  // public GetAreaList() {
  //   this._http
  //     .post(this._baseUrl + 'api/AreaController/GetAreaList', this.areaOf, this.headers)
  //     .subscribe(result => {
  //       this.hostelArea = result;
  //     });
  // }
}
