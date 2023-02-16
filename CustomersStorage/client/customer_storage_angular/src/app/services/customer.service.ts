import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CreateCustomerViewModel } from '../models/customer/create-customer-view-model';
import { GetCustomersByFilterRequestModel } from '../models/customer/get-customer-by-filter-request-model';
import { UpdateCustomerViewModel } from '../models/customer/update-customer-view-model';

@Injectable()
export class CustomerService {
    baseUrl: string;
    constructor(private http: HttpClient) {
        this.baseUrl = "https://localhost:7240";
    }

    add(model: CreateCustomerViewModel) {
        let url = this.baseUrl + "/Customer/Add";
        return this.http.post(url, model);
    }

    getById(id: number): Observable<any> {
        let url = this.baseUrl + "/Customer/GetById/" + id;
        return this.http.get(url).pipe(map((response: any) => {
            return response;
        }));
    }

    getList(): Observable<any[]> {
        let url = this.baseUrl + "/Customer/GetList";
        return this.http.get(url).pipe(map((response: any) => {
            return response;
        }));
    }

    getListByFilter(model: GetCustomersByFilterRequestModel): Observable<any[]> {
        let url = this.baseUrl + "/Customer/GetByFilter";
        return this.http.post(url, model).pipe(map((response: any) => {
            return response;
        }));
    }

    edit(model: UpdateCustomerViewModel) {
        let url = this.baseUrl + "/Customer/Edit";
        return this.http.post(url, model);
    }

    remove(id: number) {
        let url = this.baseUrl + "/Customer/Remove/" + id;
        return this.http.get(url);
    }
}
