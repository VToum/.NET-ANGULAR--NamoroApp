import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from './../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {
  @Output() cancelarCadastro = new EventEmitter();
  model: any = {}

  constructor(private accountService: AccountService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  cadastro() {
    this.accountService.cadastro(this.model).subscribe({
      next: () => {
        this.cancelar();
      },
      error: error =>{
        this.toastr.error(error.error),
        console.log(error);
      }

    })
  }

  cancelar() {
    this.cancelarCadastro.emit(false);
  }

}
