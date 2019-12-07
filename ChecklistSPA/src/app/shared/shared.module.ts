import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './footer/footer.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule, MatInputModule  } from '@angular/material';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MainNavComponent } from './main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatListModule } from '@angular/material/list';

@NgModule({
  declarations: [ FooterComponent, MainNavComponent],
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatIconModule,
    MatButtonModule,
    MatInputModule,
    MatTabsModule,
    MatToolbarModule,
    MatSidenavModule,
    LayoutModule,
    MatListModule
  ],
  exports: [
    MatFormFieldModule,
    MainNavComponent,
    FooterComponent,
    MatIconModule,
    MatButtonModule,
    MatInputModule,
    MatTabsModule,
    MatToolbarModule,
    MatSidenavModule
  ]
})
export class SharedModule { }
