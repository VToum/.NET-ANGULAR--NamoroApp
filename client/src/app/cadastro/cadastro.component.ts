import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from './../_services/account.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {
  @Output() cancelarCadastro = new EventEmitter();
  model: any = {}

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  cadastro() {
    this.accountService.cadastro(this.model).subscribe({
      next: () => {
        this.cancelar();
      },
      error: error => console.log(error)
    })
  }

  cancelar() {
    this.cancelarCadastro.emit(false);
  }

}
