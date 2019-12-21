import { Component, OnInit } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  checkInterceptor(){
    console.log('start checking');

    this.http.get(`https://localhost:44370/api/user/private`).subscribe(
      ok => console.log(ok),
      error => console.log(error)
    );
  }

}
