import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, HttpClientModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  @Input() loginEndpoint = "";
  @Output() returnToken = new EventEmitter();
  loginForm: FormGroup = this.fb.group({
    username: [],
    password: []
  });

  constructor(private fb: FormBuilder, private http: HttpClient) {
  }

  async login() {
    const loginDetails = this.loginForm.value;
    const loginAction = this.http.post(this.loginEndpoint, null, {
      params: {
        username: loginDetails.username,
        password: loginDetails.password
      },
      responseType: 'text'
    });
    this.returnToken.emit(await lastValueFrom<string>(loginAction))
    // this.token = await lastValueFrom<string>(loginAction);
  }
}
