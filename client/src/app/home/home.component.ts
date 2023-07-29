import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  cadastroMode = false;
  usuario: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getUser();
  }

  cadastroToggle(){
    this.cadastroMode = !this.cadastroMode;
  }

  getUser() {
    this.http.get('https://localhost:5001/api/usuario').subscribe({
      next: (response) => (this.usuario = response),
      error: (error) => console.log(error),
      complete: () => console.log('Request has completed'),
    });
  }

  cancelarCadastroMode(event: boolean){
    this.cadastroMode = event;
  }

}
