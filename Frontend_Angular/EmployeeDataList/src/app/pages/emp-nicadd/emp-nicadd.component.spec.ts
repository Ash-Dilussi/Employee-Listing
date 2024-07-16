import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpNICaddComponent } from './emp-nicadd.component';

describe('EmpNICaddComponent', () => {
  let component: EmpNICaddComponent;
  let fixture: ComponentFixture<EmpNICaddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EmpNICaddComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EmpNICaddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
