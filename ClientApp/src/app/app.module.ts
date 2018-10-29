// Angular Core
import { NgModule } from "@angular/core";
import { HttpModule } from "@angular/http";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// Components
import { AppComponent } from './core/app/app.component';
import { HomeComponent } from './core/home/home.component';
import { NavMenuComponent } from './core/nav-menu/nav-menu.component';
// Modules
import { SharedModule } from "./shared/shared.module";
import { DialogsModule } from "./dialogs/dialog.module";

// Services
import { ShareService } from "./shared/share.service";
import { AuthService } from "./core/auth/auth.service";
import { MessageService } from "./shared/message.service";
import { AuthGuard } from "./core/auth/auth-guard.service";
import { HttpErrorHandler } from "./shared/http-error-handler.service";
import { LoginComponent } from "./users/login/login.component";
import { RegisterComponent } from "./users/register/register.component";
import { CustomMaterialModule } from "./shared/customer-material.module";

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    // Angular Core
    HttpModule,
    FormsModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    // Modules
    DialogsModule,
    CustomMaterialModule,
    //SharedModule,
    // Router
    RouterModule.forRoot([
      { path: "", redirectTo: "home", pathMatch: "full" },
      { path: "home", component: HomeComponent },
      { path: "login", component: LoginComponent },
      { path: "register/:condition", component: RegisterComponent },
      { path: "register", component: RegisterComponent },
      {
        path: "plan",
        loadChildren: './plans/plan.module#PlanModule',
        canActivate: [AuthGuard]
      },
      {
        path: "stardard-time",
        loadChildren: './standard-times/standard-time.module#StandardTimeModule',
        canActivate: [AuthGuard]
      },
      {
        path: "bom",
        loadChildren: './bill-materials/bill-material.module#BillMaterialModule',
        canActivate: [AuthGuard]
      },
      {
        path: "rate",
        loadChildren: "./rate-manhours/rate-manhour.module#RateManhourModule",
        canActivate: [AuthGuard]
      },
      {
        path: "actual",
        loadChildren: "./actual-masters/actual-master.module#ActualMasterModule",
        canActivate: [AuthGuard]
      },
      {
        path: "workgroup",
        loadChildren: "./workgroups/workgroup.module#WorkgroupModule",
        canActivate: [AuthGuard]
      },
      { path: "**", redirectTo: "home" },
    ]),
  ],
  providers: [
    AuthGuard,
    AuthService,
    ShareService,
    MessageService,
    HttpErrorHandler,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
