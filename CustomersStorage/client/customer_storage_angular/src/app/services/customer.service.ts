import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ICreateCustomerViewModel } from '../models/customer/create-customer-view-model';
import { IGetCustomersByFilterRequestModel } from '../models/customer/get-customer-by-filter-request-model';
import { IUpdateCustomerViewModel } from '../models/customer/update-customer-view-model';
import { environment } from 'src/assets/environments/environment';
import { ICustomerViewModel } from '../models/customer/customer-view-model';
import { ICustomerSampleViewModel } from '../models/customer/customer-sample-view-model';

@Injectable({
    providedIn: 'root',
})
export class CustomerService {
    baseUrl: string;
    constructor(private http: HttpClient) {
        this.baseUrl = environment.baseUrl;
    }

    add(model: ICreateCustomerViewModel): Observable<any> {
        let url = this.baseUrl + "/Customer/Add";
        return this.http.post(url, model);
    }

    getListByFilter(model: IGetCustomersByFilterRequestModel): Observable<ICustomerSampleViewModel> {
        let url = this.baseUrl + "/Customer/GetByFilter";
        return this.http.post(url, model).pipe(map((item: any) => {
            return item;
        }));
    }

    edit(model: IUpdateCustomerViewModel): Observable<any> {
        let url = this.baseUrl + "/Customer/Edit";
        return this.http.post(url, model);
    }

    remove(id: number): Observable<any> {
        let url = this.baseUrl + "/Customer/Remove/" + id;
        return this.http.get(url);
    }

    getAllNames(): Observable<string[]>{
        let url = this.baseUrl + "/Customer/GetAllNames";
        return this.http.get(url).pipe(map((item: any) => {
            return item;
        }));
    }
}
