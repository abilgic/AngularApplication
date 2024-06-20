import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Product {
  id: number
  name: string;
  price: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public products: Product[] = [];
  public apiUrl: string = 'http://localhost:5252/api/Product';
  isShowSaveBtn = false;
  isShowUpdateBtn = false;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getproducts();
  }
  displayStyle = "none";

  openPopup() {
    this.displayStyle = "block";
    this.isShowSaveBtn = true;
    this.isShowUpdateBtn = false;
    (document.getElementById("ProductModalLabel") as HTMLInputElement).innerHTML = "Save Product";
  }
  openPopupUpdate() {
    this.displayStyle = "block";
    this.isShowSaveBtn = false;
    this.isShowUpdateBtn = true;
    (document.getElementById("ProductModalLabel") as HTMLInputElement).innerHTML = "Update Product";
  }
  closePopup() {
    this.displayStyle = "none";
  }


  getproducts() {
    this.http.get<Product[]>(this.apiUrl).subscribe(
      (result) => {
        this.products = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  getProduct(val: any) {
    this.isShowSaveBtn = false;
    this.isShowUpdateBtn = true;
    this.http.get<Product>(this.apiUrl + '/' + val).subscribe(
      (result) => {
        (document.getElementById("ProductId") as HTMLInputElement).value = result.id.toString();
        (document.getElementById("ProductName") as HTMLInputElement).value = result.name;
        (document.getElementById("Price") as HTMLInputElement).value = result.price.toString();
      },
      (error) => {
        console.error(error);
      }
    );
  }

  updateProduct() {
    let Product = {
      id: (document.getElementById("ProductId") as HTMLInputElement).value,
      name: (document.getElementById("ProductName") as HTMLInputElement).value,
      price: (document.getElementById("Price") as HTMLInputElement).value
    }
    return this.http.put(this.apiUrl, Product).subscribe(response => {
      if (response) {
        alert("Product is Updated");
      }
      else {
        alert("Product is not updated");
      }
    });
  }

  deleteProduct(val: any) {

    return this.http.delete(this.apiUrl + '/' + val).subscribe(response => {
      if (response) {
        alert("Product is deleted");

      }
      else {

        alert("Product is not deleted");
      }
    });
  }


  createProduct() {

    let Product = {
      name: (document.getElementById("ProductName") as HTMLInputElement).value,
      price: (document.getElementById("Price") as HTMLInputElement).value
    }

    this.http.post(this.apiUrl, Product)
      .subscribe(response => {
        if (response) {
          alert("Product is Saved");
        }
        else {
          alert("Product is not saved");
        }
      });
  }

  title = 'angularapplication.client';
}
