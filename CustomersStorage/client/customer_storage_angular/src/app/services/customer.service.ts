import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CustomerCreateModel } from '../models/customer/customer-create-model';
import { CustomersSampleRequestModel } from '../models/customer/customers-sample-request-model';
import { CustomerUpdateModel } from '../models/customer/customer-update-model';
import { environment } from 'src/assets/environments/environment';
import { CustomersSampleResponseModel } from '../models/customer/customers-sample-response-model';

@Injectable({
    providedIn: 'root',
})
export class CustomerService {
    baseUrl: string;
    constructor(private http: HttpClient) {
        this.baseUrl = environment.baseUrl;
    }

    add(model: CustomerCreateModel): Observable<any> {
        let url = this.baseUrl + "/Customer/Add";
        return this.http.post(url, model);
    }

    getListByFilter(model: CustomersSampleRequestModel): Observable<CustomersSampleResponseModel> {
        let url = this.baseUrl + "/Customer/GetByFilter";
        return this.http.post(url, model).pipe(map((item: any) => {
            return item;
        }));
    }

    edit(model: CustomerUpdateModel): Observable<any> {
        let url = this.baseUrl + "/Customer/Edit";
        return this.http.post(url, model);
    }

    remove(id: number): Observable<any> {
        let url = this.baseUrl + "/Customer/Remove/" + id;
        return this.http.get(url);
    }

    getAllNames(): Observable<string[]> {
        let url = this.baseUrl + "/Customer/GetAllNames";
        return this.http.get(url).pipe(map((item: any) => {
            return item;
        }));
    }
}
