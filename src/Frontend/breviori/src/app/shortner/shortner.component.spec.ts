import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShortnerComponent } from './shortner.component';

describe('ShortnerComponent', () => {
  let component: ShortnerComponent;
  let fixture: ComponentFixture<ShortnerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShortnerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShortnerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
